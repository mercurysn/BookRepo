using System.Web.Mvc;
using Ninject;

namespace BookRepo
{
    public class IocConfig
    {
        public static void RegisterIocContainer()
        {
            IKernel kernel = new StandardKernel(new BookRepoInject());
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
            IocContainer.Instance.Initialize(kernel);
        }
    }
}