using BlazorWA.Models;
using BlazorWA.Models.Response;
using BlazorWA.Services.Interfaces;
using BlazorWA.ViewModels.Interfaces;

namespace BlazorWA.ViewModels
{
    public class UserViewModel : IUserViewModel
    {
        private readonly IUserService userService;

        public UserViewModel(IUserService userService)
        {
            this.userService = userService;
        }




        public async Task<User> GetUserInfo()
        {
            return await userService.GetUserInfoAsync();
        }

        public async Task<bool> UpdateUserInfo(User user)
        {
            return await userService.UpdateUserInfoAsync(user);
        }



        public async Task<(bool IsSuccessful, string Message)> SignUpAsync(RegisterModel registerModel)
        {
            return await userService.Register(registerModel);
        }

        public async Task<LoginResult> SignInAsync(TokenRequestModel tokenRequestModel)
        {
            return await userService.Login(tokenRequestModel);
        }

        public async Task Logout()
        {
            await userService.Logout();
        }
    }
}
