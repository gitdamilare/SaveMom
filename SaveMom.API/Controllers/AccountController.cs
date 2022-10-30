using Microsoft.AspNetCore.Mvc;
using SaveMom.Contracts;
using SaveMom.Contracts.Dtos.Identity;
using SaveMom.Services.Identity;

namespace SaveMom.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<ApiResponse<RegisterUserResponse>>> Register([FromBody] RegisterUserRequest inputDto)
        {
            if (ModelState.IsValid)
            {
                RegisterUserResponse result = await _accountService.RegisterUser(inputDto);

                if (result.IsSuccess)
                {
                    return Ok(new ApiResponse<RegisterUserResponse>
                    {
                        Result = result
                    });
                }

                return BadRequest(new ApiResponse<RegisterUserResponse>
                {
                    Success = result.IsSuccess,
                    ErrorMessage = result.Errors
                });
            }

            return BadRequest(new ApiResponse<RegisterUserResponse>()
            {
                Success = false,
                ErrorMessage = ModelState.SelectMany(m => m.Value.Errors).Select(m => m.ErrorMessage)
            });
        }

        [HttpPost("login")]
        public async Task<ActionResult<ApiResponse<LoginResponse>>> Login([FromBody] LoginRequest inputDto)
        {
            if (ModelState.IsValid)
            {
                var loginResponse = await _accountService.Login(inputDto);

                if (loginResponse.IsSuccess)
                {
                    return Ok(new ApiResponse<LoginResponse>
                    {
                        Result = loginResponse
                    });
                }

                return BadRequest(new ApiResponse<LoginResponse>
                {
                    ErrorMessage = loginResponse.Errors,
                    Success = false
                });
            }

            return BadRequest(new ApiResponse<RegisterUserResponse>()
            {
                Success = false,
                ErrorMessage = ModelState.SelectMany(m => m.Value.Errors).Select(m => m.ErrorMessage)
            });
        }

        [HttpPost("logout")]
        public async Task<IActionResult> LogOut()
        {
            await _accountService.Logout();
            return Ok();
        }
    }
}
