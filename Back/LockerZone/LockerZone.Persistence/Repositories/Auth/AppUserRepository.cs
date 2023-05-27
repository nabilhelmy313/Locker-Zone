using LockerZone.Application.Interfaces.Repositories;
using LockerZone.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace LockerZone.Persistence.Repositories
{
    public class AppUserRepository : IAppUserRepository
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;

        public AppUserRepository(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<TokenEntity> GetToken(string userName, string password, string topSecretKey, string issuer, string audience)
        {
             var result = await _signInManager.PasswordSignInAsync(userName, password, true, false);
            if (result.Succeeded)
            {
                var user = await _userManager.FindByEmailAsync(userName);
                var roles = await _userManager.GetRolesAsync(user!);

                var claims = new[]
                {
                            new Claim(JwtRegisteredClaimNames.NameId, user.Id.ToString()),
                            new Claim(JwtRegisteredClaimNames.UniqueName, userName),
                            new Claim(JwtRegisteredClaimNames.Email, user.Email),
                            new Claim(JwtRegisteredClaimNames.GivenName,  user.FullName),
                            new Claim(JwtRegisteredClaimNames.Website,  user.FullName),
                        };
                if (!user.IsActive) return new TokenEntity { IsActive = false };
                if (Encoding.UTF8.GetBytes(topSecretKey).Length < 32)
                {
                    // Truncate or expand the secret key to meet the minimum key size requirement
                    byte[] keyBytes = new byte[32];
                    Encoding.UTF8.GetBytes(topSecretKey).CopyTo(keyBytes, 0);
                    topSecretKey = Encoding.UTF8.GetString(keyBytes);
                }
                var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(topSecretKey));
                var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                    issuer: issuer,
                    audience: audience,
                    expires: DateTime.Now.AddDays(1),
                    claims: claims,
                    signingCredentials: signingCredentials
                );
                
                ApplicationRole role = new ApplicationRole
                {
                    Name = roles.FirstOrDefault(),
                    NormalizedName = roles.FirstOrDefault(),
                };
                user.UserRoles.Add(role);

                try
                {
                    return new TokenEntity
                    {
                        Token = new JwtSecurityTokenHandler().WriteToken(token),
                        Expiration = token.ValidTo,
                        CurrentUser = user,
                        IsActive = user.IsActive,
                        RoleName = roles.FirstOrDefault()
                    };
                }
                catch (Exception ex)
                {

                    throw;
                }
            }
            return new TokenEntity();
        }

        public async Task<ApplicationUser> GetUserByEmail(string email)
        {
            var user = await _userManager.Users.Where(x => x.Email == email).FirstOrDefaultAsync();
            return user!;
        }

        public async Task AddRoleToUser(ApplicationUser user, string Role)
        {
            await _userManager.AddToRoleAsync(user, Role);
        }

        public async Task<List<ApplicationUser>> GetEmployers()
        {
            var user = await _userManager.Users.Where(a => a.CompanyName != "").Include(a => a.UserRoles).ToListAsync();
            return user;
        }

        public async Task<ApplicationUser> GetUserById(Guid userid)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(a => a.Id == userid);
            return user!;
        }
    }
}
