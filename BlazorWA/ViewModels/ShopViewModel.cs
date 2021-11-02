namespace BlazorWA.ViewModels
{
    public class ShopViewModel
    {
        public string Search { get; set; } = "";

        public int PageSize { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageCount { get; set; } = 10;
        public int ResultCount { get; set; }


        public string PriceFrom { get; set; } = "";
        public string PriceTo { get; set; } = "";

        public string Space { get; set; } = "";
        public string SpaceFrom { get; set; } = "";
        public string SpaceTo { get; set; } = "";

        public string City { get; set; } = "";

        public string RequestString()
        {
            var requestString = string.Empty;
            if (!string.IsNullOrEmpty(Search))
                requestString = requestString + "search?QueryName=" + Search;
            if (!string.IsNullOrEmpty(PageSize.ToString()))
                requestString = requestString + "&PageSize=" + PageSize.ToString();
            if (!string.IsNullOrEmpty(PageNumber.ToString()))
                requestString = requestString + "&PageNumber=" + PageNumber.ToString();

            if (!string.IsNullOrEmpty(PriceFrom))
                requestString = requestString + "&PriceFrom=" + PriceFrom;
            if (!string.IsNullOrEmpty(PriceTo))
                requestString = requestString + "&PriceTo=" + PriceTo;

            if (!string.IsNullOrEmpty(SpaceFrom))
                requestString = requestString + "&SpaceFrom=" + SpaceFrom;
            if (!string.IsNullOrEmpty(SpaceTo))
                requestString = requestString + "&SpaceTo=" + SpaceTo;



            return requestString;
        }
    }
}
