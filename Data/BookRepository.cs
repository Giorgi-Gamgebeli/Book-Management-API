using BookManagement.DTOs;
using BookManagement.DTOs.requests;
using BookManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace BookManagement.Data
{
    public class BookRepository
    {
        private readonly BooksDbContext _context;

        public BookRepository(BooksDbContext context)
        {
            _context = context;
        }

        public async Task<List<Book>> GetAllBooks()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<(List<BooksNamesDto> Books, int TotalCount)> GetBooksNames(
            GetBooksReqDto pagination
        )
        {
            var query = _context
                .Books.Where(book => !book.IsDeleted)
                .OrderByDescending(b =>
                    b.BookViews * 0.5 + (DateTime.Now.Year - b.PublicationYear) * 2
                );

            var totalCount = await query.CountAsync();

            var books = await query
                .Skip((pagination.PageNumber - 1) * pagination.PageSize)
                .Take(pagination.PageSize)
                .Select(book => new BooksNamesDto { Id = book.Id, Title = book.Title })
                .ToListAsync();

            return (books, totalCount);
        }

        public async Task<List<Book>> GetBooksByIds(List<int> ids)
        {
            return await _context
                .Books.Where(b => ids.Contains(b.Id) && !b.IsDeleted)
                .ToListAsync();
        }

        public async Task<Book?> GetBookById(int id)
        {
            var book = await _context
                .Books.Where(b => b.Id == id && !b.IsDeleted)
                .FirstOrDefaultAsync();

            return book;
        }

        public async Task AddBooks(List<Book> books)
        {
            await _context.Books.AddRangeAsync(books);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Book>> GetBooksByTitles(List<string> titles)
        {
            return await _context.Books.Where(b => titles.Contains(b.Title)).ToListAsync();
        }

        public async Task UpdateBook(Book book)
        {
            _context.Books.Update(book);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBook(Book book)
        {
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBooks(List<Book> books)
        {
            foreach (var book in books)
            {
                book.IsDeleted = true;
            }
            await _context.SaveChangesAsync();
        }
    }
}
