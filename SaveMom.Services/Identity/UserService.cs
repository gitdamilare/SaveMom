using Microsoft.AspNetCore.Identity;
using MongoDB.Driver;
using SaveMom.Contracts.Dtos.Identity;
using SaveMom.Domain.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace SaveMom.Services.Identity
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;

        public UserService(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<bool> AddClaimToUser(AddClaimsRequest claimsInputDto)
        {
            var user = await _userManager.FindByEmailAsync(claimsInputDto.Email);

            if(user == null)
            {
                return false;
            }

            var createClaims = claimsInputDto.Claims.Select(c => new Claim(c.Claim ?? "", c.Value ?? ""));
            var addClaim = await _userManager.AddClaimsAsync(user, createClaims);

            if (addClaim.Succeeded)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> RemoveUserClaim(AddClaimsRequest claimsInputDto)
        {
            var user = await _userManager.FindByEmailAsync(claimsInputDto.Email);

            if (user == null)
            {
                return false;
            }

            var createClaims = claimsInputDto.Claims.Select(c => new Claim(c.Claim ?? "", c.Value ?? ""));
            var removeClaims = await _userManager.RemoveClaimsAsync(user, createClaims);

            if (removeClaims.Succeeded)
            {
                return true;
            }

            return false;
        }

        public async Task<List<Claim>> GetUserClaims(string userEmail)
        {
            var user = await _userManager.FindByEmailAsync(userEmail);

            if(user == null)
            {
                return new List<Claim>();
            }

            IdentityOptions _options = new IdentityOptions();
            var claims = new List<Claim>
            {
                new Claim("Id", user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(_options.ClaimsIdentity.UserIdClaimType, user.Id.ToString()),
                new Claim(_options.ClaimsIdentity.UserNameClaimType, user.UserName),
            };

            

            var userClaims = await _userManager.GetClaimsAsync(user);
            claims.AddRange(userClaims);

            var userRoles = await _userManager.GetRolesAsync(user);
            foreach (var userRole in userRoles)
            {
                claims.Add(new Claim(ClaimsIdentity.DefaultRoleClaimType, userRole));
                var role = await _roleManager.FindByNameAsync(userRole);
                if (role != null)
                {
                    var roleClaims = await _roleManager.GetClaimsAsync(role);
                    foreach (Claim roleClaim in roleClaims)
                    {
                        claims.Add(roleClaim);
                    }
                }
            }
            return claims;
        }
    }
}
