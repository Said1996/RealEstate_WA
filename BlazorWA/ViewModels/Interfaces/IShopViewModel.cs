using BlazorWA.Models;

namespace BlazorWA.ViewModels.Interfaces
{
    public interface IShopViewModel
    {
        string SearchQuery { get; set; }

        int PageSize { get; set; }
        int CurrentPage { get; set; }
        int TotalPages { get; set; }
        int ResultCount { get; set; }



        string PriceFrom { get; set; }
        string PriceTo { get; set; }

        string Space { get; set; }
        string MinSpace { get; set; }
        string MaxSpace { get; set; }

        string BedroomNum { get; set; }
        string BathroomNum { get; set; }

        string City { get; set; }

        RealEstate[] RealEstateData { get; set; }



        Task Search();
    }
}
