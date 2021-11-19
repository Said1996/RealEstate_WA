using BlazorWA.Models;
using BlazorWA.Models.Response;

namespace BlazorWA.Services.Interfaces
{
    public interface IUserService
    {
        Task<(bool IsSuccessful, string Message)> Register(RegisterModel registerModel);
        Task<LoginResult> Login(TokenRequestModel tokenRequestModel);
        Task Logout();
    }
}
