using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using BookRepo.Data.Models;
using BookRepo.Data.Repository;
using BookRepo.Helpers.AutoMapper;

namespace BookRepo.Controllers
{
    public class LibraryController : Controller
    {
        private readonly BookRespository _bookRespository;

        public LibraryController(BookRespository bookRespository)
        {
            _bookRespository = bookRespository;
            //Mapper.Initialize(cfg => cfg.AddProfile(new MapToViewModelProfile()));

        }

        public ActionResult Index()
        {
            var booksVm = GetBookVm();

            return View(booksVm);
        }

        private List<Models.ViewModels.Book> GetBookVm()
        {
            List<Book> books = _bookRespository.GetBooks();

            List<Models.ViewModels.Book> booksVm = new List<Models.ViewModels.Book>();

            foreach (var book in books)
            {
                Models.ViewModels.Book bookVm = new Models.ViewModels.Book();

                Mapper.Map(book, bookVm);

                booksVm.Add(bookVm);
            }

            return booksVm;
        }
    }
}