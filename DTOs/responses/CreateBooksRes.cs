namespace BookManagement.DTOs.responses
{
    public class CreateBooksResDto
    {
        public int Status { get; set; } = 200;
        public required string Success { get; set; }
        public required List<BookDto> Data { get; set; }
    }
}
