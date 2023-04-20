using LockerZone.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace LockerZone.Persistence
{
    public class LockerZoneDbContext: IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LockerZoneDbContext(DbContextOptions<LockerZoneDbContext> options, IHttpContextAccessor httpContextAccessor) : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        #region AuditSaveChanges        
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            var currentUserId = _httpContextAccessor.HttpContext?.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Created_By = currentUserId != null ? Guid.Parse(currentUserId) : Guid.Empty;
                        entry.Entity.Created_Date = DateTime.Now;
                        break;

                    case EntityState.Modified:
                        entry.Entity.Last_Modified_By = Guid.Parse(currentUserId!);
                        entry.Entity.Last_Modified_Date = DateTime.Now;
                        break;

                }
            }
            return await base.SaveChangesAsync(cancellationToken);
        }
        #endregion
    }
}
