using System.Data.Entity;
using BookRepo.Data.Models;

namespace BookRepo.Data
{
    public class BookDb : DbContext
    {
        public BookDb() : base("DefaultConnection")
        {
            
        }

        public DbSet<Book> Books { get; set; }
    }
}