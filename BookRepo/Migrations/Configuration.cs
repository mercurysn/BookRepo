using BookRepo.Data;
using BookRepo.Data.Models;

namespace BookRepo.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<BookDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(BookDb context)
        {
            context.Books.AddOrUpdate(
                b => b.Id,
            new Book
            {
                Id = 1,
                Author = "J. K. Rowling",
                Name = "Harry Potter and the Goblet of Fire"
            });
        }
    }
}
