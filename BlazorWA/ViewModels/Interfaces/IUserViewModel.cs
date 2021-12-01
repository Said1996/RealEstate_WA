using BlazorWA.Models;
using BlazorWA.Models.Response;
using Microsoft.AspNetCore.Components.Forms;

namespace BlazorWA.ViewModels.Interfaces
{
    public interface IUserViewModel
    {

        Task<string> UploadAsync(IBrowserFile file);
        Task<User> GetUserInfo();
        Task<(bool IsSuccessful, string Message)> SignUpAsync(RegisterModel registerModel);
        Task<LoginResult> SignInAsync(TokenRequestModel tokenRequestModel);
        Task<bool> UpdateUserInfo(User user);
        Task Logout();
    }
}
