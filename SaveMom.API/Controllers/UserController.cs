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

        [HttpPost("/addclaims")]
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

        [HttpPost("/removeclaims")]
        public async Task<ActionResult<ApiResponse<object>>> RemoveUserClaim([FromBody] AddClaimsRequest claimsInputDto)
        {
            var result = await _userService.RemoveUserClaim(claimsInputDto);

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

        [HttpGet("{email}")]
        public async Task<ActionResult<ApiResponse<object>>> GetUserClaims(string email)
        {
            var result = await _userService.GetUserClaims(email);

            if (result.Any())
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
