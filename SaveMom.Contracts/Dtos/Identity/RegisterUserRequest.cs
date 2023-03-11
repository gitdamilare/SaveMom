
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace SaveMom.Contracts.Dtos.Identity
{
    public class RegisterUserRequest
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [Phone]
        public string? PhoneNumber { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Password and Confirmation Password does not match")]
        public string? ConfirmPassword { get; set; }

        public string? UserName { get; set; }

        [Required]
        public Guid RoleId { get; set; }

        [Required]
        public string OrganisationId { get; set; }

        public IFormFile? File { get; set; }
    }
}
