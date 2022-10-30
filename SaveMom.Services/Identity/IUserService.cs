using SaveMom.Contracts.Dtos.Identity;
using SaveMom.Domain.Identity;
using System.Security.Claims;

namespace SaveMom.Services.Identity
{
    public interface IUserService
    {
        //Task GetAllRoles();
        //Task GetAllUsers();
        //Task<ClaimsPrincipal> GetRoles();
        //Task<string> GetUserRoles(string email);
        //Task AddUserToRole(string email, string roleName);
        //Task RemoveUserFromRole(string email, string roleName);
        Task<List<Claim>> GetUserClaims(AppUser user);

        Task<bool> AddClaimToUser(AddClaimsRequest claimsInputDto);
    }
}
