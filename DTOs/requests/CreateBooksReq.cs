using System.ComponentModel.DataAnnotations;

namespace BookManagement.DTOs.requests
{
    public class CreateBooksReqDto
    {
        [Required(ErrorMessage = "Title is required")]
        [MaxLength(255, ErrorMessage = "Title cannot be longer than 255 characters")]
        public required string Title { get; set; }

        [Required(ErrorMessage = "Publication Year is required")]
        [Range(0, 2025, ErrorMessage = "Publication Year must be between 0 and 2025")]
        public int PublicationYear { get; set; }

        [Required(ErrorMessage = "Author Name is required")]
        [MaxLength(255, ErrorMessage = "Author Name cannot be longer than 255 characters")]
        public required string AuthorName { get; set; }
    }
}
