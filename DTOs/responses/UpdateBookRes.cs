namespace BookManagement.DTOs.responses
{
    public class UpdateBookResDto
    {
        public int Status { get; set; } = 200;
        public required string Success { get; set; }
        public required BookDto Data { get; set; }
    }
}
