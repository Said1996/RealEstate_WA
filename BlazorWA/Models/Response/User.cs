using RealEstateApi.Models.Request;

namespace BlazorWA.Models.Response
{
    public class User
    {
        public string FullName { get; set; }
        public bool IsAuthenticated { get; set; }
        public string PhotoPath { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public ICollection<RealEstateModel> UserRealEstatesOffer { get; set; }
    }
}
