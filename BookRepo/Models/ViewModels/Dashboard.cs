namespace BookRepo.Models.ViewModels
{
    public class Dashboard
    {
        public Book FastestBook { get; set; }
        public Book LongestBook { get; set; }
        public Book MostRecentBook { get; set; }
        public DashboardSummary DashboardSummary { get; set; }
    }
}