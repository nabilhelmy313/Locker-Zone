using LockerZone.Application;
using LockerZone.Application.Interfaces.Repositories;
using LockerZone.Application.Interfaces.Services.General;
using LockerZone.Application.Services.Auth;
using LockerZone.Domain.Entities;
using LockerZone.Persistence;
using LockerZone.Persistence.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Persistence;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
#region IdentityCoreAuth
builder.Services.AddIdentity<ApplicationUser, ApplicationRole>()
    .AddEntityFrameworkStores<LockerZoneDbContext>()
    .AddDefaultTokenProviders();
builder.Services.AddDbContext<LockerZoneDbContext>(options =>
{

    options.UseSqlServer(builder.Configuration .GetConnectionString("LockerZoneDBConnStr"));
    options.EnableSensitiveDataLogging();

});
builder.Services.Configure<IdentityOptions>(options =>
{
    // Default Password settings.
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 8;
    options.Password.RequiredUniqueChars = 0;
});
#endregion
builder.Services.AddHttpContextAccessor();

// Add mulit Languages support
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new List<System.Globalization.CultureInfo>
                {
                    new System.Globalization.CultureInfo("en-US"),
                };

    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;

    options.RequestCultureProviders.Insert(0, new Microsoft.AspNetCore.Localization.CustomRequestCultureProvider(context =>
    {
        var defaultLang = "en-US";
        var lang = context.Request.Headers["Accept-Language"].ToString();
        if (!string.IsNullOrWhiteSpace(lang) && lang.ToString().Length > 4 && lang.ToString().Substring(2, 1) == "-")
            defaultLang = lang.ToString().Substring(0, 5);
        var localization = Task.FromResult(new Microsoft.AspNetCore.Localization.ProviderCultureResult(defaultLang, defaultLang));
        return localization!;
    }));
});



builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

#region JWT
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer("Bearer", options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["Jwt:Key"])),
        ValidateIssuer = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidateAudience = true,
        ValidAudience = builder.Configuration["Jwt:Audience"],
    };
});
#endregion

builder.Services.AddAutoMapper(typeof(MappingProfileBase));

builder.Services.AddCors(c =>
{
    c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin());
});
#region Repo
builder.Services.AddScoped<IAppUserRepository, AppUserRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
#endregion

#region Services
builder.Services.AddScoped<IUserService, UserService>();

#endregion
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(x => x
               .AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader());
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
