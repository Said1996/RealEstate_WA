namespace BlazorWA.Models.Response
{
    public class LoginResult
    {
        public string Message { get; set; }
        public bool IsSuccessful { get; set; }
        public string FullName { get; set; }
        public string PhotoPath { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public string Token { get; set; }
    }
}
