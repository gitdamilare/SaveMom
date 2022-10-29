
using Microsoft.AspNetCore.Mvc;
using SaveMom.IdentityApp.Dtos;
using SaveMom.IdentityApp.Services;

namespace SaveMom.IdentityApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse<object>>> AddClaimToUser([FromBody] AddClaimsRequest claimsInputDto)
        {
            var result = await _userService.AddClaimToUser(claimsInputDto);

            if (result)
            {
                return Ok(new ApiResponse<object>()
                {
                    Result = result
                });
            }

            return Ok(new ApiResponse<object>()
            {
                Success = false,
                Result = result
            });
        }
    }
}
