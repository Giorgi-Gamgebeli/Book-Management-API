using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookManagement.DTOs.requests
{
    public class GetBooksReqDto
    {
        [DefaultValue(1)]
        [Range(1, int.MaxValue, ErrorMessage = "Page number must be greater than 0")]
        public int PageNumber { get; set; } = 1;

        [DefaultValue(10)]
        [Range(1, int.MaxValue, ErrorMessage = "Page size must be greater than 0")]
        public int PageSize { get; set; } = 10;
    }
}
