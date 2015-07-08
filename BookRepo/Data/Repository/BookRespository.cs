using System.Collections.Generic;
using System.Linq;
using BookRepo.Data.Models;

namespace BookRepo.Data.Repository
{
    public class BookRespository : IBookRespository
    {
        public List<Book> GetBooks()
        {
            using (var context = new BookDb())
            {
               return (from book in context.Books select book).ToList();
            }
        }
    }
}