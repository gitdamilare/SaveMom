using SaveMom.IdentityApp.Dtos;
using SaveMom.IdentityApp.Models;
using System.Security.Claims;

namespace SaveMom.IdentityApp.Services
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
