using BlazorApp10.Models;
using Microsoft.EntityFrameworkCore;
using BlazorApp10.Data;
using BlazorApp10.Interfaces.Repositories;
using BlazorApp10.Models;

namespace BlazorApp10.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly BookDbContext _db;
        private readonly ILogger<BookRepository> _logger;

        public BookRepository(BookDbContext db, ILogger<BookRepository> logger)
        {
            _db = db;
            _logger = logger;
        }
        public async Task<List<Book>> GetAllAsync()
        {
            try
            {
                return await _db.Books.ToListAsync();

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving all equipment.");
                throw;
            }
        }
        public async Task<Book?> GetByIdAsync(int id)
        {
            try
            {
                var book = await _db.Books.FindAsync(id);
                if (book is null)
                {
                    _logger.LogWarning($"Book with ID {id} not found.");
                }
                return book;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while retrieving book with ID {id}.");
                throw;
            }
        }
        public async Task<bool> AddAsync(Book book)
        {
            try
            {
                await _db.Books.AddAsync(book);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while adding new Book.");
                return false;
            }
        }
        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var book = await _db.Books.FindAsync(id);
                if (book is null)
                {
                    _logger.LogWarning($"Book with ID {id} not found for deletion.");
                    return false;
                }
                _db.Books.Remove(book);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while deleting book with ID {id}.");
                return false;
            }
        }

    }
}