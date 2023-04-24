
namespace LockerZone.Domain.Dtos
{
    public class TokenDto
    {
        public string Token { get; set; }=string.Empty;
        public DateTime Expiration { get; set; }
        public ApplicationUserDto CurrentUser { get; set; } = default!;
        public string RoleName { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }

    public class ApplicationUserDto
    {
        public string? UserName { get; set;}
        public string? FullName { get; set; }
        public string RoleName { get; set; } = default!;
        public string? ProfilePicture { get; set; }
    }

}
