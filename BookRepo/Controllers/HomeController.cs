using System.Linq;
using System.Security.Cryptography;
using System.Web.Mvc;
using BookRepo.Data;

namespace BookRepo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (var context = new BookDb())
            {
                var books = from b in context.Books where b.Name == "Harry Potter" select b;
            }
            return View();
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