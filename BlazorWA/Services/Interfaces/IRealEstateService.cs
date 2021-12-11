using BlazorWA.Models;
using BlazorWA.Models.Response;

namespace BlazorWA.Services.Interfaces
{
    public interface IRealEstateService
    {
        Task<(bool isSuccess, SearchPaginationResponse pagination, RealEstate[] realEstates)> SearchRequest(string searchQuery);
        Task<bool> PostRealEstate(RealEstate realEstate);
    }
}
