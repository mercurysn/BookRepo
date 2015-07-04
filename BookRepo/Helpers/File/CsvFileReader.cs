using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using BookRepo.Data.Models;
using CsvHelper;

namespace BookRepo.Helpers.File
{
    public class CsvFileReader
    {
        public CsvReader Reader { get; set; }
        public List<Book> Books = new List<Book>();

        public void OpenFile()
        {
            TextReader textReader = System.IO.File.OpenText(@"C:\Users\e053227\Source\Repos\BookRepo\BookRepo\Source\Books - Sheet1.csv");
            Reader = new CsvReader(textReader);
            ConfigureCsvReader();
        }

        private void ConfigureCsvReader()
        {
            Reader.Configuration.RegisterClassMap<FieldMapper>();
            Reader.Configuration.IgnoreHeaderWhiteSpace = true;
        }

        public void GetAllRecords()
        {
            List<BookDto> bookDtos = Reader.GetRecords<BookDto>().ToList();
            
            foreach (var bookDto in bookDtos)
            {
                Book book  = new Book();

                Mapper.Map(bookDto, book);

                Books.Add(book);
            }
        }
    }
}