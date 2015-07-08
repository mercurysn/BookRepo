using System.Collections.Generic;
using BookRepo.Data.Models;

namespace BookRepo.Data.Repository
{
    public interface IBookRespository
    {
        List<Book> GetBooks();
    }
}