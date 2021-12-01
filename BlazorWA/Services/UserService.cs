using Blazored.LocalStorage;
using BlazorWA.Models;
using BlazorWA.Models.Response;
using BlazorWA.Services.Interfaces;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace BlazorWA.Services
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        private readonly ILocalStorageService _localStorage;

        public UserService(HttpClient httpClient,
                           AuthenticationStateProvider authenticationStateProvider,
                           ILocalStorageService localStorage)
        {
            _httpClient = httpClient;
            _authenticationStateProvider = authenticationStateProvider;
            _localStorage = localStorage;
        }

        public async Task<(bool IsSuccessful, string Message)> Register(RegisterModel registerModel)
        {
            var registerAsJson = JsonSerializer.Serialize(registerModel);
            var response = await _httpClient.PostAsync("User/Register", new StringContent(registerAsJson, Encoding.UTF8, "application/json"));
            //var registerResult = JsonSerializer.Deserialize<RegisterResult>(await response.Content.ReadAsStringAsync());


            return (response.IsSuccessStatusCode, await response.Content.ReadAsStringAsync());
        }

        public async Task<LoginResult> Login(TokenRequestModel tokenRequestModel)
        {
            var loginAsJson = JsonSerializer.Serialize(tokenRequestModel);
            var response = await _httpClient.PostAsync("User/SignIn", new StringContent(loginAsJson, Encoding.UTF8, "application/json"));
            var loginResult = JsonSerializer.Deserialize<LoginResult>(await response.Content.ReadAsStringAsync(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            if (!response.IsSuccessStatusCode)
            {
                return loginResult;
            }

            await _localStorage.SetItemAsync("authToken", loginResult.Token);
            await _localStorage.SetItemAsync("expiryDate", loginResult.Expiry);


            ((ApiAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsAuthenticated(loginResult);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", loginResult.Token);

            return loginResult;
        }

        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("authToken");
            await _localStorage.RemoveItemAsync("expiryDate");
            ((ApiAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsLoggedOut();
            _httpClient.DefaultRequestHeaders.Authorization = null;
        }

        public async Task<User> GetUserInfoAsync()
        {
            var response = await _httpClient.GetAsync("User");
            var user = await response.Content.ReadFromJsonAsync<User>();

            return user;
        }

        public async Task<bool> UpdateUserInfoAsync(User user)
        {
            var response = await _httpClient.PutAsJsonAsync("User", user);
            return response.IsSuccessStatusCode;
        }

        public async Task<string> UploadFileAsync(UploadedFile uploadedFile)
        {
            var response = await _httpClient.PostAsJsonAsync("FileUpload", uploadedFile);
            var result = await response.Content.ReadAsStringAsync();
            return result;
        }
    }
}
