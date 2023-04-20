using Domain.Resources;
using System.ComponentModel.DataAnnotations;

namespace LockerZone.Domain.Dtos
{
    public class RegisterDto
    {
        [Display(Name = nameof(DtoResource.FullName), ResourceType = typeof(DtoResource))]
        [Required(ErrorMessageResourceName = nameof(DtoResource.IsRequried), ErrorMessageResourceType = typeof(DtoResource))]
        public string FullName { get; set; } = string.Empty;
        [Display(Name = nameof(DtoResource.Email), ResourceType = typeof(DtoResource))]
        [EmailAddress(ErrorMessageResourceName = nameof(DtoResource.CorrectWay), ErrorMessageResourceType = typeof(DtoResource))]
        [Required(ErrorMessageResourceName = nameof(DtoResource.IsRequried), ErrorMessageResourceType = typeof(DtoResource))]
        public string Email { get; set; }=string.Empty;
        [Display(Name = nameof(DtoResource.Password), ResourceType = typeof(DtoResource))]
        [Required(ErrorMessageResourceName = nameof(DtoResource.IsRequried), ErrorMessageResourceType = typeof(DtoResource))]
        public string Password { get; set; }= string.Empty;
    }
}
