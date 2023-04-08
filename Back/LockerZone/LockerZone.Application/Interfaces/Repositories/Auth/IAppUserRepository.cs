using LockerZone.Domain.Entities;

namespace LockerZone.Application.Interfaces.Repositories
{
    public interface IAppUserRepository
    {
        Task<TokenEntity> GetToken(string userName, string password, string topSecretKey, string issuer, string audience);
        Task<ApplicationUser> GetUserByEmail(string email);
        Task<ApplicationUser> GetUserById(Guid id);
        Task AddRoleToUser(ApplicationUser user, string Role);
        Task<List<ApplicationUser>> GetEmployers();


    }
}
