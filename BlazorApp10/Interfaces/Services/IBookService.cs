using BlazorApp10.Models;
using BlazorApp10.Models;

namespace BlazorApp10.Interfaces.Services
{
    public interface IBookService
    {
        Task<List<Book>> GetAllAsync();
        Task<Book?> GetByIdAsync(int id);
        Task<bool> AddAsync(Book book);
        Task<bool> DeleteAsync(int id);
    }
}