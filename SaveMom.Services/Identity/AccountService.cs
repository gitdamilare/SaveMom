using Mapster;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SaveMom.Contracts.Configurations;
using SaveMom.Contracts.Dtos.Identity;
using SaveMom.Domain.Identity;
namespace SaveMom.Services.Identity
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly IAzureBlobService _azureBlobService;
        private readonly ILogger<AccountService> _logger;

        private readonly AzureBlobStorageOptions _storeOptions;

        public AccountService(
            UserManager<AppUser> userManager,
            RoleManager<AppRole> roleManager,
            SignInManager<AppUser> signInManager,
            ITokenService jwtTokenService,
            ILogger<AccountService> logger,
            IAzureBlobService azureBlobService,
            IOptions<AzureBlobStorageOptions> storeOptions)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _tokenService = jwtTokenService;
            _azureBlobService = azureBlobService;
            _logger = logger;
            _storeOptions = storeOptions.Value;
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

        public async Task<RegisterUserResponse> RegisterUser(RegisterUserRequest inputDto)
        {
            var getUser = await _userManager.FindByEmailAsync(inputDto.Email);

            if(getUser != null)
            {
                return new RegisterUserResponse()
                {
                    IsSuccess = false,
                    Errors = new List<string> { $"{inputDto.Email} already exist" }
                };
            }

            var newUser = inputDto.Adapt<AppUser>();
            var createUser = await _userManager.CreateAsync(newUser, inputDto.Password);

            var userId = newUser.Id.ToString();
            if (createUser.Succeeded)
            {
                _logger.LogInformation(1, "User Created");

                //Upload User Information
                newUser.IdentityDocumentUrl = await UploadUserDocument(inputDto, userId);
                await _userManager.UpdateAsync(newUser);

                var getRole = _roleManager.Roles.FirstOrDefault(xx => xx.Id == inputDto.RoleId);

                //catch error or set gobal error ... delete user if role could not be added
                var addUserRole = await _userManager.AddToRoleAsync(newUser, getRole?.Name);

                if (addUserRole.Succeeded)
                {
                    _logger.LogInformation(2, "Role Add to User Created");
                    return new RegisterUserResponse
                    {
                        Email = inputDto.Email
                    };

                }

                return new RegisterUserResponse
                {
                    IsSuccess = false,
                    Errors = createUser.Errors.Select(e => e.Description).ToList()
                };
            }

            return new RegisterUserResponse
            {
                IsSuccess = false,
                Errors = createUser.Errors.Select(e => e.Description).ToList()
            };
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }

        private async Task<string> UploadUserDocument(RegisterUserRequest inputDto, string userId)
        {
            var file = inputDto.File;
            var fileName = GenerateFileName(file.FileName, userId);
            using (Stream stream = file.OpenReadStream())
            {
                string fileUri = await _azureBlobService.UploadFileToStorage(stream, fileName, _storeOptions.VerificationContainerName);
                return fileUri;
            }
        }

        private string GenerateFileName(string fileName, string userId)
        {
            string createFileName = $"{userId}-{fileName.Split('.')[0]}.{fileName.Split('.')[1]}";
            return createFileName;
        }
    }
}
