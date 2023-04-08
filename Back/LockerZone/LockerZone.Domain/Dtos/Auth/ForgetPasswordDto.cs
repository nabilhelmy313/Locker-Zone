using System.ComponentModel.DataAnnotations;

namespace LockerZone.Domain.Dto.General.Auth
{
    public class ForgetPasswordDto
    {
        [Required(ErrorMessage = "Email Filed is Required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address ex:example@gmail.com")]
        public string Email { get; set; }=string.Empty;
        [Required(ErrorMessage = "Url Filed is Required")]
        public string Url { get; set; }= string.Empty;
    }
}
