using Microsoft.AspNetCore.Mvc;
using SaveMom.Contracts;
using SaveMom.Contracts.Dtos.Identity;
using SaveMom.Services.Identity;

namespace SaveMom.IdentityApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
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
