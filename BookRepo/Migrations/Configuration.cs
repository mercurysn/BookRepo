using AutoMapper;
using BookRepo.Data;
using BookRepo.Helpers.AutoMapper;
using BookRepo.Helpers.File;

namespace BookRepo.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<BookDb>
    {
        public Configuration()
        {
            Mapper.Initialize(cfg => cfg.AddProfile(new BookMapperProfile()));
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(BookDb context)
        {
            CsvFileReader fileReader = new CsvFileReader();

            fileReader.OpenFile();

            fileReader.GetAllRecords();

            var id = 2;

            foreach (var book in fileReader.Books)
            {
                book.Id = id++;
                context.Books.AddOrUpdate(
                    b => b.Id, book);
            }
        }
    }
}
