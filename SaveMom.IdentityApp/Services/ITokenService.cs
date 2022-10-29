using SaveMom.IdentityApp.Models;

namespace SaveMom.IdentityApp.Services
{
    public interface ITokenService
    {
        public Task<string> GenerateAccessToken(AppUser user);
        public string GenerateRefreshToken();
    }
}