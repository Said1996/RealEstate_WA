using BlazorWA.Models;
using BlazorWA.Models.Response;

namespace BlazorWA.ViewModels.Interfaces
{
    public interface IUserViewModel
    {
        public User User { get; set; }
        public string Token { get; set; }



        Task<(bool IsSuccessful, string Message)> SignUpAsync(RegisterModel registerModel);
        Task<LoginResult> SignInAsync(TokenRequestModel tokenRequestModel);
        Task Logout();
    }
}
