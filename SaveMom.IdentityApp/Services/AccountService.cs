using Mapster;
using Microsoft.AspNetCore.Identity;
using SaveMom.IdentityApp.Dtos;
using SaveMom.IdentityApp.Models;

namespace SaveMom.IdentityApp.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly ILogger<AccountService> _logger;

        public AccountService(
            UserManager<AppUser> userManager,
            RoleManager<AppRole> roleManager,
            SignInManager<AppUser> signInManager,
            ITokenService jwtTokenService,
            ILogger<AccountService> logger)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _tokenService = jwtTokenService;
            _logger = logger;
        }

        public async Task<LoginResponse> Login(LoginRequest inputDto)
        {
            var user = await _userManager.FindByEmailAsync(inputDto.Email);
            if (user == null) 
            { 
                return new LoginResponse
                {
                    IsSuccess = false,
                    Errors = new List<string> { $"{inputDto.Email} does not exist" }
                };
            }

            var isPasswordCorrect = await _userManager.CheckPasswordAsync(user, inputDto.Password);
            if (isPasswordCorrect)
            {
                var accessToken = await _tokenService.GenerateAccessToken(user);
                var refreshToken = _tokenService.GenerateRefreshToken();

                return new LoginResponse
                {
                    AccessToken = accessToken,
                    RefreshToken = refreshToken
                };
            }

            return new LoginResponse
            {
                IsSuccess = false,
                Errors =new List<string> { $"username and password does not match" }
            };
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<RegistrationResponse> RegisterUser(RegistrationRequest inputDto)
        {
            var getUser = await _userManager.FindByEmailAsync(inputDto.Email);

            if(getUser != null)
            {
                return new RegistrationResponse()
                {
                    IsSuccess = false,
                    Errors = new List<string> { $"{inputDto.Email} already exist" }
                };
            }

            var newUser = inputDto.Adapt<AppUser>();
            var createUser = await _userManager.CreateAsync(newUser, inputDto.Password);

            if (createUser.Succeeded)
            {
                _logger.LogInformation(1, "User Created");

                var getRole = _roleManager.Roles.FirstOrDefault(xx => xx.Id == inputDto.RoleId);
                var addUserRole = await _userManager.AddToRoleAsync(newUser, getRole?.Name);

                if (addUserRole.Succeeded)
                {
                    _logger.LogInformation(2, "Role Add to User Created");
                    return new RegistrationResponse
                    {
                        Email = inputDto.Email
                    };
                }

                return new RegistrationResponse
                {
                    IsSuccess = false,
                    Errors = createUser.Errors.Select(e => e.Description).ToList()
                };
            }

            return new RegistrationResponse
            {
                IsSuccess = false,
                Errors = createUser.Errors.Select(e => e.Description).ToList()
            };
        }
    }
}
