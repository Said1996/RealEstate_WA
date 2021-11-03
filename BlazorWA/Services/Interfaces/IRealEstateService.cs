namespace BlazorWA.Services.Interfaces
{
    public interface IRealEstateService
    {
        Task<HttpResponseMessage> SearchRequest(string searchQuery);
    }
}
