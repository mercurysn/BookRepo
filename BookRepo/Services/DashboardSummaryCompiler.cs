using BookRepo.Data.Repository;
using BookRepo.Models.ViewModels;

namespace BookRepo.Services
{
    public class DashboardSummaryCompiler
    {
        private readonly IBookRespository _bookRespository;

        public DashboardSummaryCompiler(IBookRespository bookRespository)
        {
            _bookRespository = bookRespository;            
        }

        public DashboardSummary Get()
        {


            return new DashboardSummary();
        }
    }
}