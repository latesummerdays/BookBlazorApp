using BlazorApp10.Models;
using Microsoft.EntityFrameworkCore;
using BlazorApp10.Models;
namespace BlazorApp10.Data
{
    public class BookDbContext : DbContext
    {
        public BookDbContext(DbContextOptions<BookDbContext> options)
            : base(options)
        {

        }
        public DbSet<Book> Books { get; set; }
        //test test tett
    }
}