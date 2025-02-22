using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BookManagement.Models
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore]
        public int Id { get; set; }

        public required string Title { get; set; }
        public required int PublicationYear { get; set; }
        public required string AuthorName { get; set; }

        [JsonIgnore]
        public int BookViews { get; set; } = 0;

        [JsonIgnore]
        public bool IsDeleted { get; set; } = false;
    }
}
