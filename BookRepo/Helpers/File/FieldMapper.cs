using CsvHelper.Configuration;

namespace BookRepo.Helpers.File
{
    public sealed class FieldMapper : CsvClassMap<BookDto>
    {
        public FieldMapper()
        {
            Map(m => m.Book);
            Map(m => m.Author);
            Map(m => m.Time);
            Map(m => m.DateStarted);
            Map(m => m.DateEnded);
        }
    }
}