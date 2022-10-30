using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SaveMom.Contracts.Configurations;
using SaveMom.Domain.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SaveMom.Services.Identity
{
    public class TokenService : ITokenService
    {
        private readonly IOptions<JwtOptions> _jwtOptions;
        private readonly IUserService _userService;


        public TokenService(IOptions<JwtOptions> jwtOptions, IUserService userService)
        {
            _jwtOptions = jwtOptions;
            _userService = userService;
        }

        public async Task<string> GenerateAccessToken(AppUser user)
        {
            var options = _jwtOptions.Value;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(options.SecretKey ?? "");

            var claims = await _userService.GetUserClaims(user);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = options.Issuer,
                Audience = options.Audience,
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(options.ExpirationInDays),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public string GenerateRefreshToken()
        {
            return string.Empty;
        }
    }
}
