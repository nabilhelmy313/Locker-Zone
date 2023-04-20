using Microsoft.AspNetCore.Identity;
namespace LockerZone.Domain.Entities
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string FullName { get; set; }=String.Empty;
        public bool IsActive { get; set; }=true;
        public string? CompanyName{ get; set; }
        public virtual ICollection<ApplicationRole> UserRoles { get; set; } = new List<ApplicationRole>();

    }
}
