using System.Collections.Generic;
using BookRepo.Models.ViewModels;
using System.Linq;


namespace BookRepo.Services
{
    public static class StatsMonthMapper
    {
        public static List<MonthByMonthItem> MapBookListToMonthByMonthList(List<Book> books)
        {
            var result = books.GroupBy(b => new {b.DateCompleted.Value.Year, b.DateCompleted.Value.Month}).ToList();

            List<MonthByMonthItem> monthByMonthItems = new List<MonthByMonthItem>();

            foreach (var bookGroup in result)
            {
                MonthByMonthItem list = new MonthByMonthItem
                {
                    Month = string.Concat(bookGroup.Key.Year, "/", bookGroup.Key.Month),
                    TotalBooks = bookGroup.Count(),
                    TotalPages = bookGroup.Sum(b => b.Pages),
                    Minutes = bookGroup.Sum(b => b.Minutes),
                    Books = bookGroup.ToList()
                };

                monthByMonthItems.Add(list);
            }

            return AddRankColumn(monthByMonthItems);

            //return monthByMonthItems.OrderByDescending(m => m.Minutes).ToList();
        }

        private static List<MonthByMonthItem> AddRankColumn(List<MonthByMonthItem> monthByMonthItems)
        {
            return (from m in monthByMonthItems
                orderby m.Minutes descending
                select new MonthByMonthItem
                {
                    Month = m.Month,
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