using BlazorWA.ViewModels.Interfaces;

namespace BlazorWA.ViewModels
{
    public class UserViewModel : IUserViewModel
    {
        public string Token { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string PhotoPath { get; set; }

        public string PhoneNumber { get; set; }

    }
}
