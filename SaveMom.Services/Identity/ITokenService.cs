using SaveMom.Domain.Identity;

namespace SaveMom.Services.Identity
{
    public interface ITokenService
    {
        public Task<string> GenerateAccessToken(AppUser user);
        public string GenerateRefreshToken();
    }
}