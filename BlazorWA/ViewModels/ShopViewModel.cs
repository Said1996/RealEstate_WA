using BlazorWA.Models;
using BlazorWA.Models.Response;
using BlazorWA.Services.Interfaces;
using BlazorWA.ViewModels.Interfaces;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;

namespace BlazorWA.ViewModels
{
    public class ShopViewModel : IShopViewModel
    {
        private readonly IRealEstateService realEstateService;

        public ShopViewModel(IRealEstateService realEstateService)
        {
            this.realEstateService = realEstateService;
        }

        public string SearchQuery { get; set; } = "";

        public int PageSize { get; set; } = 9;
        public int CurrentPage { get; set; } = 1;
        public int TotalPages { get; set; }
        public int ResultCount { get; set; }

        public bool DisableNext { get; set; } = true;
        public bool DisablePrev { get; set; } = true;

        public string PriceFrom { get; set; } = "";
        public string PriceTo { get; set; } = "";

        public string Space { get; set; } = "";
        public string MinSpace { get; set; } = "";
        public string MaxSpace { get; set; } = "";



        public string BedroomNum { get; set; }
        public string BathroomNum { get; set; }

        public string City { get; set; } = "";

        public RealEstate[] RealEstateData { get; set; }

        public EventCallback PageClick { get; set; }

        public async Task Search()
        {
            var searchQuery = RequestString();

            var response = await realEstateService.SearchRequest(searchQuery);
            if (response != null)
            {
                PaginationBinding(response);
                var content = await response.Content.ReadAsStringAsync();
                RealEstateData = JsonConvert.DeserializeObject<RealEstate[]>(content);
            }
        }

        private void PaginationBinding(HttpResponseMessage response)
        {
            var pagination = response.Headers.FirstOrDefault(h => h.Key == "x-pagination").Value.FirstOrDefault();
            if (pagination != null)
            {
                var header = JsonConvert.DeserializeObject<SearchResponseModel>(pagination);
                if (header != null)
                {
                    TotalPages = header.TotalPages;
                    ResultCount = header.TotalCount;
                    CurrentPage = header.PageNumber;
                    DisableNext = !header.HasNext;
                    DisablePrev = !header.HasPrevious;
                }
            }

        }

        private string RequestString()
        {
            var requestString = "RealEstate/search?";
            if (!string.IsNullOrEmpty(SearchQuery))
                requestString = requestString + "Search=" + SearchQuery;
            if (!string.IsNullOrEmpty(PageSize.ToString()))
                requestString = requestString + "&PageSize=" + PageSize.ToString();
            if (!string.IsNullOrEmpty(CurrentPage.ToString()))
                requestString = requestString + "&PageNumber=" + CurrentPage.ToString();

            if (!string.IsNullOrEmpty(PriceFrom))
                requestString = requestString + "&PriceFrom=" + PriceFrom;
            if (!string.IsNullOrEmpty(PriceTo))
                requestString = requestString + "&PriceTo=" + PriceTo;

            if (!string.IsNullOrEmpty(BedroomNum))
                requestString = requestString + "&BedroomNum=" + BedroomNum;
            if (!string.IsNullOrEmpty(BathroomNum))
                requestString = requestString + "&BathroomNum=" + BathroomNum;

            if (!string.IsNullOrEmpty(MinSpace))
                requestString = requestString + "&MinSpace=" + MinSpace;
            if (!string.IsNullOrEmpty(MaxSpace))
                requestString = requestString + "&MaxSpace=" + MaxSpace;



            return requestString;
        }
    }
}
