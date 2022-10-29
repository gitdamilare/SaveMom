using System.ComponentModel.DataAnnotations;

namespace SaveMom.IdentityApp.Dtos
{
    public class RegistrationRequest
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Password and Confirmation Password does not match")]
        public string? ConfirmPassword { get; set; }

        public string? UserName { get; set; }

        public string? RoleId { get; set; }
    }
}
