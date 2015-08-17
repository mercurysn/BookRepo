using System.Web.Mvc;

namespace BookRepo.Controllers
{
    public class StatsController : Controller
    {
        // GET: Stats
        public ActionResult Month()
        {
            return View();
        }
    }
}