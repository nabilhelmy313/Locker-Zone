using LockerZone.Application.Interfaces.Repositories;
using LockerZone.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
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
                        };
                if (!user.IsActive) return new TokenEntity { IsActive = false };
                var superSecretPassword = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(topSecretKey));

                var token = new JwtSecurityToken(
                    issuer: issuer,
                    audience: audience,
                    expires: DateTime.Now.AddDays(1),
                    claims: claims,
                    signingCredentials: new SigningCredentials(superSecretPassword, SecurityAlgorithms.HmacSha256)
                );
                ApplicationRole role = new ApplicationRole
                {
                    Name = roles.FirstOrDefault(),
                    NormalizedName = roles.FirstOrDefault(),
                };
                user.UserRoles.Add(role);
               
                return new TokenEntity
                {
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    Expiration = token.ValidTo,
                    CurrentUser = user,
                    IsActive = user.IsActive,
                    RoleName=roles.FirstOrDefault()
                };
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
