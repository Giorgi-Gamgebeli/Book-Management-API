namespace BookManagement.DTOs
{
    public class BookDto
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string AuthorName { get; set; }
        public int PublicationYear { get; set; }
        public int BookViews { get; set; }
    }

    public class BooksNamesDto
    {
        public required int Id { get; set; }

        public required string Title { get; set; }
    }
}
