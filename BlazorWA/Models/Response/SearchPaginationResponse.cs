namespace BlazorWA.Models.Response
{
    public class SearchPaginationResponse
    {
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
        public int PageNumber { get; set; }

        public bool HasNext { get; set; }
        public bool HasPrevious { get; set; }

    }
}
