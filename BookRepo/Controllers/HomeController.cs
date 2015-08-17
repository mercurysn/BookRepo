using System.Web.Mvc;
using AutoMapper;
using BookRepo.Data.Dtos;
using BookRepo.Data.Repository;
using BookRepo.Models.ViewModels;

namespace BookRepo.Controllers
{
    public class HomeController : Controller
    {
        private readonly BookRespository _bookRespository;

        public HomeController(BookRespository bookRespository)
        {
            _bookRespository = bookRespository;
            

        }

        public ActionResult Index()
        {
            Dashboard dashboard = new Dashboard
            {
                FastestBook = Mapper.Map<Book>(_bookRespository.GetFastestBook()) ,
                LongestBook = Mapper.Map<Book>(_bookRespository.GetLongestBook()) ,
                MostRecentBook = Mapper.Map<Book>(_bookRespository.GetMostRecentBook()),
                DashboardSummary = Mapper.Map<DashboardSummary>(_bookRespository.GetDashboardDto())
            };
             
            return View(dashboard);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}