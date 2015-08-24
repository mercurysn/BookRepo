using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using BookRepo.Data.Repository;
using BookRepo.Models.ViewModels;
using BookRepo.Services;

namespace BookRepo.Controllers
{
    public class StatsController : Controller
    {
        private readonly BookRespository _bookRespository;

        public StatsController(BookRespository bookRespository)
        {
            _bookRespository = bookRespository;

        }

        public ActionResult Month()
        {
            MonthStatsViewModel viewModel = new MonthStatsViewModel
            {
                MonthByMonthList = StatsMonthMapper.MapBookListToMonthByMonthList(Mapper.Map<List<Book>>(_bookRespository.GetBooks()))
            };

            return View(viewModel);
        }
    }
}