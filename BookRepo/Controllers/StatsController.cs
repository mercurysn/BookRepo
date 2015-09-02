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
                MonthByMonthList = StatsMapper.MapBookListToMonthByMonthList(Mapper.Map<List<Book>>(_bookRespository.GetBooks())),
                MonthList = StatsMapper.MapBookListToMonthList(Mapper.Map<List<Book>>(_bookRespository.GetBooks()))
            };

            return View(viewModel);
        }

        public ActionResult Year()
        {
            YearStatsViewModel viewModel = new YearStatsViewModel
            {
                YearByYearList = StatsMapper.MapBookListToYearList(Mapper.Map<List<Book>>(_bookRespository.GetBooks()))
            };

            return View(viewModel);
        }

        public ActionResult Book()
        {
            return View(Mapper.Map<List<Book>>(_bookRespository.GetBooks()));
        }
    }
}