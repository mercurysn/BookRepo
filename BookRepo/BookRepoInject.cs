using BookRepo.Data.Repository;
using Ninject.Modules;

namespace BookRepo
{
    public class BookRepoInject : NinjectModule
    {
        public override void Load()
        {
            Bind<IBookRespository>().To<BookRespository>();
        }
    }
}