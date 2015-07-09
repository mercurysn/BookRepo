using AutoMapper;
using BookRepo.Data.Models;
using BookRepo.Helpers.ExtensionMethods;

namespace BookRepo.Helpers.AutoMapper
{
    public class MapToViewModelProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Book, Models.ViewModels.Book>()
                .ForMember(dest => dest.RunningTime, src => src.MapFrom(p => p.Minutes.ToHourMinuteDisplay()))
                ;

            Mapper.AssertConfigurationIsValid();
        }
    }
}