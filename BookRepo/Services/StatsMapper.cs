using System.Collections.Generic;
using BookRepo.Models.ViewModels;
using System.Linq;


namespace BookRepo.Services
{
    public static class StatsMapper
    {
        public static List<BookGroup> MapBookListToMonthByMonthList(List<Book> books)
        {
            var result = books.GroupBy(b => new {b.DateCompleted.Value.Year, b.DateCompleted.Value.Month}).ToList();

            List<BookGroup> monthByMonthItems = result.Select(bookGroup => new BookGroup
            {
                GroupName = string.Concat(bookGroup.Key.Year, "/", bookGroup.Key.Month), 
                TotalBooks = bookGroup.Count(), 
                TotalPages = bookGroup.Sum(b => b.Pages), 
                Minutes = bookGroup.Sum(b => b.Minutes), 
                Books = bookGroup.ToList()
            }).ToList();

            return AddRankColumn(monthByMonthItems);
        }

        public static List<BookGroup> MapBookListToMonthList(List<Book> books)
        {
            var result = books.GroupBy(b => new { b.DateCompleted.Value.Month }).ToList();

            List<BookGroup> monthByMonthItems = result.Select(bookGroup => new BookGroup
            {
                GroupName = bookGroup.Key.Month.ToString(),
                TotalBooks = bookGroup.Count(),
                TotalPages = bookGroup.Sum(b => b.Pages),
                Minutes = bookGroup.Sum(b => b.Minutes),
                Books = bookGroup.ToList()
            }).ToList();

            return AddRankColumn(monthByMonthItems);
        }

        public static List<BookGroup> MapBookListToYearList(List<Book> books)
        {
            var result = books.GroupBy(b => new { b.DateCompleted.Value.Year }).ToList();

            List<BookGroup> items = result.Select(bookGroup => new BookGroup
            {
                GroupName = bookGroup.Key.Year.ToString(),
                TotalBooks = bookGroup.Count(),
                TotalPages = bookGroup.Sum(b => b.Pages),
                Minutes = bookGroup.Sum(b => b.Minutes),
                Books = bookGroup.ToList()
            }).ToList();

            return AddRankColumn(items);
        }

        private static List<BookGroup> AddRankColumn(List<BookGroup> monthByMonthItems)
        {
            return (from m in monthByMonthItems
                orderby m.Minutes descending
                select new BookGroup
                {
                    GroupName = m.GroupName,
                    TotalBooks = m.TotalBooks,
                    TotalPages = m.TotalPages,
                    Minutes = m.Minutes,
                    Books = m.Books,
                    Rank = (from s in monthByMonthItems
                        where s.Minutes > m.Minutes
                        select s).Count() + 1
                }).ToList();
        }
    }
}