
using AspNetCore.Identity.MongoDbCore.Models;
using MongoDbGenericRepository.Attributes;
using System.ComponentModel.DataAnnotations;

namespace SaveMom.Domain.Identity
{
    [CollectionName("AppUsers")]
    public class AppUser : MongoIdentityUser<Guid>
    {
        [Required]
        [MaxLength(250)]
        public string? FirstName { get; set; }

        [Required]
        [MaxLength(250)]
        public string? LastName { get; set; }

        public string? IdentityDocumentUrl { get; set; }
    }
}
