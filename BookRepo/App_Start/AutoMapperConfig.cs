using AutoMapper;
using BookRepo.Helpers.AutoMapper;

namespace BookRepo.App_Start
{
    public class AutoMapperConfig
    {
        public static void RegisterMapper()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile(new MapToViewModelProfile());
                cfg.AddProfile(new BookMapperProfile());
            });
        }
    }
}