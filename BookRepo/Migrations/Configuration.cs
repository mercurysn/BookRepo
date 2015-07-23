using AutoMapper;
using BookRepo.Data;
using BookRepo.Data.Models;
using BookRepo.Helpers;
using BookRepo.Helpers.AutoMapper;
using BookRepo.Helpers.File;

namespace BookRepo.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<BookDb>
    {
        public Configuration()
        {
            //Mapper.Initialize(cfg => cfg.AddProfile(new BookMapperProfile()));
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

                SetCoverHash(book);

                context.Books.AddOrUpdate(
                    b => b.Id, book);
            }
        }

        private static void SetCoverHash(Book book)
        {
            ImageConverter converter = new ImageConverter();

            book.CoverHash = converter.ConvertImageUrlToBase64(book.CoverUrl);
        }
    }
}
