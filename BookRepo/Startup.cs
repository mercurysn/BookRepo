using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BookRepo.Startup))]
namespace BookRepo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
