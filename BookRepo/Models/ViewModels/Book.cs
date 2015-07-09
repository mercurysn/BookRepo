using System;

namespace BookRepo.Models.ViewModels
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string RunningTime { get; set; }
        public DateTime? DateStarted { get; set; }
        public DateTime? DateCompleted { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public int Pages { get; set; }
        public string CoverUrl { get; set; }
    }
}