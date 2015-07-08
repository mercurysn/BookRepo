using AutoMapper;
using BookRepo.Data.Models;

namespace BookRepo.Helpers.AutoMapper
{
    public class MapToViewModelProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Book, Models.ViewModels.Book>()
                .ForMember(dest => dest.Id, src => src.MapFrom(p => p.Id))
                ;

            Mapper.AssertConfigurationIsValid();
        }
    }
}