using BlazorApp10.Interfaces.Services;
using BlazorApp10.Models;
using BlazorApp10.Interfaces.Repositories;
using BlazorApp10.Interfaces.Services;
using BlazorApp10.Models;
using BlazorApp10.Repositories;

namespace BlazorApp10.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly ILogger<BookService> _logger;
        public BookService(IBookRepository bookRepository, ILogger<BookService> logger)
        {
            _bookRepository = bookRepository;
            _logger = logger;
        }
        public async Task<List<Book>> GetAllAsync()
        {
            try
            {
                return await _bookRepository.GetAllAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving all books.");
                throw;
            }
        }
        public async Task<Book?> GetByIdAsync(int id)
        {
            try
            {
                return await _bookRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while retrieving books with ID {id}.");
                throw;
            }
        }
        public async Task<bool> AddAsync(Book book)
        {
            try
            {
                return await _bookRepository.AddAsync(book);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while adding new books.");
                return false;
            }
        }
        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                return await _bookRepository.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while deleting book with ID {id}.");
                return false;
            }
        }
    }
}