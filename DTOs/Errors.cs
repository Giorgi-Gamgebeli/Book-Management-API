namespace BookManagement.DTOs
{
    public class NotFoundDto
    {
        public required string Error { get; set; }
        public int Status { get; set; } = 404;
        public string type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.4";
    }

    public class ConflictDto
    {
        public required string Error { get; set; }
        public int Status { get; set; } = 409;
        public string type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.8";
    }
}
