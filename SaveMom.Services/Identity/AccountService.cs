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
        private readonly IOrganisationService _organisationService;
        private readonly ILogger<AccountService> _logger;

        private readonly AzureBlobStorageOptions _storeOptions;

        public AccountService(
            UserManager<AppUser> userManager,
            RoleManager<AppRole> roleManager,
            SignInManager<AppUser> signInManager,
            ITokenService jwtTokenService,
            ILogger<AccountService> logger,
            IAzureBlobService azureBlobService,
            IOptions<AzureBlobStorageOptions> storeOptions,
            IOrganisationService organisationService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _tokenService = jwtTokenService;
            _azureBlobService = azureBlobService;
            _logger = logger;
            _storeOptions = storeOptions.Value;
            _organisationService = organisationService;
        }

        public async Task<LoginResponse> Login(LoginRequest inputDto)
        {
            var user = await _userManager.FindByEmailAsync(inputDto.Username) == null 
                ? await _userManager.FindByNameAsync(inputDto.Username) 
                : await _userManager.FindByEmailAsync(inputDto.Username);

            if (user == null) 
            { 
                return new LoginResponse
                {
                    IsSuccess = false,
                    Errors = new List<string> { $"{inputDto.Username} does not exist" }
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

            var getRole = _roleManager.Roles.FirstOrDefault(xx => xx.Id == inputDto.RoleId);
            var validateInputDto = await ValidateRegisterUser(inputDto, getRole);

            if (!validateInputDto.IsSuccess)
            {
                return validateInputDto;
            }

            var newUser = inputDto.Adapt<AppUser>();

            //Create user
            var createUser = await _userManager.CreateAsync(newUser, inputDto.Password);

            if(!createUser.Succeeded) 
            {
                return new RegisterUserResponse
                {
                    IsSuccess = false,
                    Errors = createUser.Errors.Select(e => e.Description).ToList()
                };
            }

            _logger.LogInformation(1, "User Created");

            //Add role to user
            var addUserRole = await _userManager.AddToRoleAsync(newUser, getRole?.Name);

            try
            {
                newUser.IdentityDocumentUrl = await UploadUserDocument(inputDto, newUser.Id.ToString());

                if (!string.IsNullOrEmpty(newUser.IdentityDocumentUrl))
                {
                    await _userManager.UpdateAsync(newUser);
                }
                else
                {
                    //delete user
                    await _userManager.DeleteAsync(newUser);
                }

                _logger.LogInformation(2, "User document uploaded");

                return new RegisterUserResponse
                {
                    Email = inputDto.Email
                };
            }
            catch (Exception)
            {
                //delete user
                await _userManager.DeleteAsync(newUser);
                throw;
            }
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }

        public List<UserRoleResponse> GetRoles()
        {
            var roles = _roleManager.Roles.Where(xx => xx.IsUserRole).ToList();
            var userroles = roles.Adapt<List<UserRoleResponse>>();
            return userroles;
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

        private async Task<RegisterUserResponse> ValidateRegisterUser(RegisterUserRequest inputDto, AppRole? appRole)
        {
            //Check if the role exists
            if (appRole == null)
            {
                return new RegisterUserResponse()
                {
                    IsSuccess = false,
                    Errors = new List<string> { $"Role Id {inputDto.RoleId} does not exist" }
                };
            }

            //Check if Organisation exists
            var getOrgnisation = await _organisationService.Get(inputDto.OrganisationId);

            if (getOrgnisation == null)
            {
                return new RegisterUserResponse()
                {
                    IsSuccess = false,
                    Errors = new List<string> { $"Orgnisation Id {inputDto.OrganisationId} does not exist" }
                };
            }

            return new RegisterUserResponse();
        }
    }
}
