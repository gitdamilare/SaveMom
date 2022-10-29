using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SaveMom.IdentityApp.Dtos;
using SaveMom.IdentityApp.Services;

namespace SaveMom.IdentityApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse<RegistrationResponse>>> Register([FromBody] RegistrationRequest inputDto)
        {
            if (ModelState.IsValid)
            {
                RegistrationResponse result = await _accountService.RegisterUser(inputDto);

                if (result.IsSuccess)
                {
                    return Ok(new ApiResponse<RegistrationResponse>
                    {
                        Result = result
                    });
                }

                return BadRequest(new ApiResponse<RegistrationResponse>
                {
                    Success = result.IsSuccess,
                    ErrorMessage = result.Errors
                });
            }

            return BadRequest(new ApiResponse<RegistrationResponse>()
            {
                Success = false,
                ErrorMessage = ModelState.SelectMany(m => m.Value.Errors).Select(m => m.ErrorMessage)
            });
        }

        [HttpPost]
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

            return BadRequest(new ApiResponse<RegistrationResponse>()
            {
                Success = false,
                ErrorMessage = ModelState.SelectMany(m => m.Value.Errors).Select(m => m.ErrorMessage)
            });
        }

        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
            await _accountService.Logout();
            return RedirectToAction("index", "home");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
    }
}
