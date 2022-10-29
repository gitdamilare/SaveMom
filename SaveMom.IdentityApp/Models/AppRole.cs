using Microsoft.AspNetCore.Identity;

namespace SaveMom.IdentityApp.Models
{
    public class AppRole : IdentityRole
    {
        public bool IsUserRole { get; set; }
        public string? Category { get; set; }
    }
}
