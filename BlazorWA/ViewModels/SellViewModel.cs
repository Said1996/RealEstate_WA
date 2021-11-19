using BlazorWA.Models;
using BlazorWA.ViewModels.Interfaces;

namespace BlazorWA.ViewModels
{
    public class SellViewModel : ISellViewModel
    {

        public string City { get; set; }

        public string Country { get; set; }

        public string Address { get; set; }

        public int Price { get; set; }

        public double Space { get; set; }

        public int BedroomNum { get; set; }

        public int BathroomNum { get; set; }

        public RegisterModel GetUser { get; set; }

    }
}
