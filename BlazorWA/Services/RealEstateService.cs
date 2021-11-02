using BlazorWA.Models;
using System.Net.Http.Json;

namespace BlazorWA.ApiCalls
{
    public class RealEstateService
    {
        private readonly HttpClient httpClient;

        public RealEstateService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<RealEstate>> Search(string searchQuery)
        {
            return await httpClient.GetFromJsonAsync<RealEstate[]>(searchQuery);
        }

    }
}
