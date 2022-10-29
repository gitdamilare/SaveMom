using Microsoft.AspNetCore.Identity;
using SaveMom.IdentityApp.Dtos;

namespace SaveMom.IdentityApp.Services
{
    public interface IAccountService
    {
        Task<LoginResponse> Login(LoginRequest inputDto);
        Task Logout();
        Task<RegistrationResponse> RegisterUser(RegistrationRequest inputDto);
    }
}