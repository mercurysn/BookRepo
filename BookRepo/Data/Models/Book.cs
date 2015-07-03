using System;

namespace BookRepo.Data.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public int Minutes { get; set; }
        public DateTime? DateStarted { get; set; }
        public DateTime? DateCompleted { get; set; }
    }
}