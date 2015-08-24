using System.Collections.Generic;

namespace BookRepo.Models.ViewModels
{
    public class MonthStatsViewModel
    {
        public List<MonthByMonthItem> MonthByMonthList { get; set; }
    }

    public class MonthByMonthItem
    {
        public string Month { get; set; }
        public int Rank { get; set; }
        public int TotalBooks { get; set; }
        public int TotalPages { get; set; }
        public int Minutes { get; set; }
        public string TotalTime { get; set; }
        public List<Book> Books { get; set; }
    }
}