using BlazorWA.Models;
using BlazorWA.Models.Response;
using BlazorWA.Services.Interfaces;
using BlazorWA.ViewModels.Interfaces;
using Microsoft.AspNetCore.Components.Forms;

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

        public async Task<string> UploadAsync(IBrowserFile file)
        {
            var resizedFile = await file.RequestImageFileAsync(file.Name, 500, 300);

            using (var stream = resizedFile.OpenReadStream())
            {
                MemoryStream ms = new MemoryStream();
                await stream.CopyToAsync(ms);
                stream.Close();

                UploadedFile uploadedFile = new UploadedFile();
                uploadedFile.FileName = file.Name;
                uploadedFile.FileContent = ms.ToArray();
                ms.Close();

                return await userService.UploadFileAsync(uploadedFile);

            }
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
