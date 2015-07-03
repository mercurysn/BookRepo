using System;
using AutoMapper;
using BookRepo.Data.Models;
using BookRepo.Helpers.ExtensionMethods;
using BookRepo.Helpers.File;

namespace BookRepo.Helpers.AutoMapper
{
    public class BookMapperProfile : Profile
    {
        protected override void Configure()
        {
            DateTime dummyTime;

            CreateMap<BookDto, Book>()
                .ForMember(dest => dest.Id, src => src.Ignore())
                .ForMember(dest => dest.Name, src => src.MapFrom(p => p.Book))
                .ForMember(dest => dest.Author, src => src.MapFrom(p => p.Author))
                .ForMember(dest => dest.Minutes, src => src.MapFrom(p => Convert.ToInt32(p.Time.ConvertTimeToMinutes())))
                .ForMember(dest => dest.DateStarted, src => src.MapFrom(p => (DateTime.TryParse(p.DateStarted, out dummyTime) ? Convert.ToDateTime(p.DateStarted) : new DateTime(1900, 1, 1))))
                .ForMember(dest => dest.DateCompleted, src => src.MapFrom(p => (DateTime.TryParse(p.DateEnded, out dummyTime) ? Convert.ToDateTime(p.DateEnded) : new DateTime(1900, 1, 1))))
                ;
            
            Mapper.AssertConfigurationIsValid();
        }
    }
}