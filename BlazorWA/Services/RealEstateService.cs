using BlazorWA.Services.Interfaces;

namespace BlazorWA.Services
{
    public class RealEstateService : IRealEstateService
    {
        private readonly HttpClient httpClient;

        public RealEstateService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> SearchRequest(string searchQuery)
        {
            var responseMessage = await httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Get, searchQuery));
            return responseMessage;
        }

    }
}
