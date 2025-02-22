using BookManagement.Data;
using BookManagement.DTOs;
using BookManagement.DTOs.requests;
using BookManagement.DTOs.responses;
using BookManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController(BookRepository bookRepository) : ControllerBase
    {
        private readonly BookRepository _bookRepository = bookRepository;

        [HttpGet]
        public async Task<IActionResult> GetBooks([FromQuery] GetBooksReqDto pagination)
        {
            var (books, totalCount) = await _bookRepository.GetBooksNames(pagination);

            if (books.Count == 0)
                return NotFound(new NotFoundDto { Error = "Couldn't find books!" });

            var totalPages = (int)Math.Ceiling(totalCount / (double)pagination.PageSize);

            return Ok(
                new GetBooksResDto
                {
                    Success = "Sucessfully retrieved books!",
                    Data = books,
                    CurrentPage = pagination.PageNumber,
                    TotalPages = totalPages,
                    PageSize = pagination.PageSize,
                    TotalCount = totalCount,
                    HasPrevious = pagination.PageNumber > 1,
                    HasNext = pagination.PageNumber < totalPages,
                }
            );
        }

        // Get a single book
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBook(int id)
        {
            var book = await _bookRepository.GetBookById(id);

            if (book == null)
                return NotFound(new NotFoundDto { Error = "Couldn't find book!" });

            book.BookViews += 1;
            await _bookRepository.UpdateBook(book);

            return Ok(
                new GetBookResDto
                {
                    Success = "Sucessfully retrieved book!",
                    Data = new BookDto
                    {
                        Id = book.Id,
                        Title = book.Title,
                        AuthorName = book.AuthorName,
                        PublicationYear = book.PublicationYear,
                        BookViews = book.BookViews,
                    },
                }
            );
        }

        // Create one or multiple
        [HttpPost]
        public async Task<IActionResult> CreateBooks([FromBody] List<CreateBooksReqDto> reqBooks)
        {
            var existingBooks = await _bookRepository.GetBooksByTitles(
                [.. reqBooks.Select(x => x.Title)]
            );
            var processedBooks = new List<Book>();

            foreach (var reqBook in reqBooks)
            {
                var existingBook = existingBooks.FirstOrDefault(b => b.Title == reqBook.Title);
                if (existingBook?.IsDeleted == false)
                    continue;

                if (existingBook?.IsDeleted == true)
                {
                    existingBook.IsDeleted = false;
                    existingBook.BookViews = 0;
                    existingBook.AuthorName = reqBook.AuthorName;
                    existingBook.PublicationYear = reqBook.PublicationYear;
                    await _bookRepository.UpdateBook(existingBook);
                    processedBooks.Add(existingBook);
                }
                else
                {
                    var newBook = new Book
                    {
                        Title = reqBook.Title,
                        AuthorName = reqBook.AuthorName,
                        PublicationYear = reqBook.PublicationYear,
                    };
                    await _bookRepository.AddBooks([newBook]);
                    processedBooks.Add(newBook);
                }
            }

            if (processedBooks.Count == 0)
            {
                return Conflict(
                    new ConflictDto { Error = "All books already exist in the database!" }
                );
            }

            return Ok(
                new CreateBooksResDto
                {
                    Success = "Sucessfully added new Books!",
                    Data =
                    [
                        .. processedBooks.Select(b => new BookDto
                        {
                            Id = b.Id,
                            Title = b.Title,
                            AuthorName = b.AuthorName,
                            PublicationYear = b.PublicationYear,
                            BookViews = b.BookViews,
                        }),
                    ],
                }
            );
        }

        // Update an existing book
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateBook(int id, [FromBody] UpdateBookReqDto reqBooks)
        {
            var book = await _bookRepository.GetBookById(id);
            if (book == null)
                return NotFound(new NotFoundDto { Error = "Couldn't find book!" });

            if (reqBooks.Title != null)
                book.Title = reqBooks.Title;

            if (reqBooks.AuthorName != null)
                book.AuthorName = reqBooks.AuthorName;

            if (reqBooks.PublicationYear.HasValue)
                book.PublicationYear = reqBooks.PublicationYear.Value;

            await _bookRepository.UpdateBook(book);

            return Ok(
                new UpdateBookResDto
                {
                    Success = "Successfully updated book!",
                    Data = new BookDto
                    {
                        Id = book.Id,
                        Title = book.Title,
                        AuthorName = book.AuthorName,
                        PublicationYear = book.PublicationYear,
                        BookViews = book.BookViews,
                    },
                }
            );
        }

        // Delete one or multiple
        [HttpDelete]
        public async Task<IActionResult> DeleteBooks([FromBody] List<int> ids)
        {
            var books = await _bookRepository.GetBooksByIds(ids);

            if (books.Count == 0)
                return NotFound(new NotFoundDto { Error = "Couldn't find book or books!" });

            await _bookRepository.DeleteBooks(books);

            return NoContent();
        }
    }
}
