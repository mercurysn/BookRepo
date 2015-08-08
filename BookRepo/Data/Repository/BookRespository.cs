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

        public Book GetLongestBook()
        {
            using (var context = new BookDb())
            {
                return context.Books.OrderByDescending(b => b.Minutes).First();
            }
        }

        public Book GetMostRecentBook()
        {
            using (var context = new BookDb())
            {
                return context.Books.OrderByDescending(b => b.DateCompleted).First();
            }
        }
    }
}