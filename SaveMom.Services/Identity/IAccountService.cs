using SaveMom.Contracts.Dtos.Identity;

namespace SaveMom.Services.Identity
{
    public interface IAccountService
    {
        Task<LoginResponse> Login(LoginRequest inputDto);
        Task Logout();
        Task<RegisterUserResponse> RegisterUser(RegisterUserRequest inputDto);
    }
}