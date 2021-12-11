using BlazorWA.Models;
using BlazorWA.Models.Response;

namespace BlazorWA.ViewModels.Interfaces
{
    public interface IUserViewModel
    {
        Task<User> GetUserInfo();
        Task<(bool IsSuccessful, string Message)> SignUpAsync(RegisterModel registerModel);
        Task<LoginResult> SignInAsync(TokenRequestModel tokenRequestModel);
        Task<bool> UpdateUserInfo(User user);
        Task Logout();
    }
}
