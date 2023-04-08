using LockerZone.Domain.Resources;
using System.ComponentModel.DataAnnotations;
namespace LockerZone.Domain.Dto.General.Auth
{
    public class LoginDto
    {
        [Display(Name = nameof(DtoResource.Email), ResourceType = typeof(DtoResource))]
        [EmailAddress(ErrorMessageResourceName = nameof(DtoResource.CorrectWay), ErrorMessageResourceType = typeof(DtoResource))]
        [Required(ErrorMessageResourceName = nameof(DtoResource.IsRequried), ErrorMessageResourceType = typeof(DtoResource))]
        public string Email { get; set; } = string.Empty;
        [Display(Name = nameof(DtoResource.Password), ResourceType = typeof(DtoResource))]
        [Required(ErrorMessageResourceName = nameof(DtoResource.IsRequried), ErrorMessageResourceType = typeof(DtoResource))]
        public string Password { get; set; }= string.Empty;
    }
}
