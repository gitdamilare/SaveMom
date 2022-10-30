using AspNetCore.Identity.MongoDbCore.Models;
using MongoDbGenericRepository.Attributes;

namespace SaveMom.Domain.Identity
{
    [CollectionName("AppRoles")]
    public class AppRole : MongoIdentityRole<Guid>
    {
        public bool IsUserRole { get; set; }
    }
}
