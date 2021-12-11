using BlazorWA.Models;
using BlazorWA.Models.Response;
using BlazorWA.Services.Interfaces;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace BlazorWA.Services
{
    public class RealEstateService : IRealEstateService
    {
        private readonly HttpClient httpClient;

        public RealEstateService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<(bool isSuccess, SearchPaginationResponse pagination, RealEstate[] realEstates)> SearchRequest(string searchQuery)
        {
            var response = await httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Get, searchQuery));
            if (response.IsSuccessStatusCode)
            {
                var realEstates = await response.Content.ReadFromJsonAsync<RealEstate[]>();

                var pagination = response.Headers.FirstOrDefault(h => h.Key == "x-pagination").Value.FirstOrDefault();
                var searchPaginationResponse = JsonConvert.DeserializeObject<SearchPaginationResponse>(pagination);

                return (true, searchPaginationResponse, realEstates);
            }
            else
                return (false, null, null);
        }

        public async Task<bool> PostRealEstate(RealEstate realEstate)
        {
            var response = await httpClient.PostAsJsonAsync("RealEstate", realEstate);
            return response.IsSuccessStatusCode;

        }


    }
}
