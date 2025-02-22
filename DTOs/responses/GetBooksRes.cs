namespace BookManagement.DTOs.responses
{
    public class GetBooksResDto
    {
        public int Status { get; set; } = 200;
        public string Success { get; set; } = "Successfully retrieved books!";

        public required List<BooksNamesDto> Data { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public bool HasPrevious { get; set; }
        public bool HasNext { get; set; }
    }
}
