using BlazorApp10.Models;
using BlazorApp10.Models;

namespace BlazorApp10.Interfaces.Repositories
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAllAsync();
        Task<Book?> GetByIdAsync(int id);
        Task<bool> AddAsync(Book book);
        Task<bool> DeleteAsync(int id);
    }
}