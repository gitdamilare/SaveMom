using System.ComponentModel.DataAnnotations;

namespace SaveMom.Contracts.Dtos.Identity
{
    public class LoginRequest
    {
        [Required]
        //This works as an email and username
        public string? Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; }
    }
}
