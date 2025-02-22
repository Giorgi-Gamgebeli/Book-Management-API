using System.ComponentModel.DataAnnotations;

namespace BookManagement.DTOs.requests
{
    public class UpdateBookReqDto
    {
        [MaxLength(255, ErrorMessage = "Title cannot be longer than 255 characters")]
        public string? Title { get; set; }

        [Range(0, 2025, ErrorMessage = "Publication Year must be between 0 and 2025")]
        public int? PublicationYear { get; set; }

        [MaxLength(255, ErrorMessage = "Author Name cannot be longer than 255 characters")]
        public string? AuthorName { get; set; }
    }
}
