using BlazorWA.Models;
using BlazorWA.Models.Response;
using BlazorWA.Services.Interfaces;
using BlazorWA.ViewModels.Interfaces;
using Microsoft.AspNetCore.Components;

namespace BlazorWA.ViewModels
{
    public class BuyViewModel : IBuyViewModel
    {
        private readonly IRealEstateService realEstateService;

        public BuyViewModel(IRealEstateService realEstateService)
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

        public string Country { get; set; } = "";
        public string City { get; set; } = "";
        public string Address { get; set; } = "";

        public RealEstate[] RealEstateData { get; set; }

        public EventCallback PageClick { get; set; }

        public async Task Search()
        {
            var searchQuery = RequestString();

            var response = await realEstateService.SearchRequest(searchQuery);
            if (response.isSuccess)
            {
                PaginationBinding(response.pagination);
                RealEstateData = response.realEstates;
            }
            else
                RealEstateData = Array.Empty<RealEstate>();

        }

        private void PaginationBinding(SearchPaginationResponse pagination)
        {
            TotalPages = pagination.TotalPages;
            ResultCount = pagination.TotalCount;
            CurrentPage = pagination.PageNumber;
            DisableNext = !pagination.HasNext;
            DisablePrev = !pagination.HasPrevious;
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

            if (!string.IsNullOrEmpty(Country))
                requestString = requestString + "&Country=" + Country;
            if (!string.IsNullOrEmpty(City))
                requestString = requestString + "&City=" + City;
            if (!string.IsNullOrEmpty(Address))
                requestString = requestString + "&Address=" + Address;

            return requestString;
        }
    }
}
