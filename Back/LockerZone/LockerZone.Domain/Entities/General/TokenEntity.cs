namespace LockerZone.Domain.Entities
{
    public class TokenEntity
    {
        public string? Token { get; set; }
        public DateTime? Expiration { get; set; }
        public ApplicationUser CurrentUser { get; set; } = default!;
        public bool IsActive { get; set; }
        public string RoleName { get; set; } = string.Empty;


    }
}
