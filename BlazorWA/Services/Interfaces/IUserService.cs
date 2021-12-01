using BlazorWA.Models;
using BlazorWA.Models.Response;

namespace BlazorWA.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> GetUserInfoAsync();
        Task<(bool IsSuccessful, string Message)> Register(RegisterModel registerModel);
        Task<LoginResult> Login(TokenRequestModel tokenRequestModel);
        Task<bool> UpdateUserInfoAsync(User user);
        Task Logout();
        Task<string> UploadFileAsync(UploadedFile uploadedFile);
    }
}
