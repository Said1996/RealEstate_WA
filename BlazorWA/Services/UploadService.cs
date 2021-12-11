using BlazorWA.Models;
using BlazorWA.Services.Interfaces;
using System.Net.Http.Json;

namespace BlazorWA.Services
{
    public class UploadService : IUploadService
    {
        private readonly HttpClient httpClient;

        public UploadService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<string> UploadFileAsync(UploadedFile uploadedFile)
        {
            var response = await httpClient.PostAsJsonAsync("FileUpload", uploadedFile);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return result;

            }
            else return "";
        }
    }
}
