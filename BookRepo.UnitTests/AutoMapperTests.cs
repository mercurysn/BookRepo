using AutoMapper;
using BookRepo.Data.Models;
using BookRepo.Helpers.AutoMapper;
using NUnit.Framework;

namespace BookRepo.UnitTests
{
    [TestFixture]
    public class AutoMapperTests
    {
        [Test]
        public void Test_AutoMapper_Mapping()
        {
            Mapper.Initialize(cfg => cfg.AddProfile(new BookMapperProfile()));

            Mapper.AssertConfigurationIsValid();
        }

        [Test]
        public void Test_MapToViewModel_Profile_Config_Valid()
        {
            Mapper.Initialize(m => m.AddProfile(new MapToViewModelProfile()));

            Mapper.AssertConfigurationIsValid();
        }

        [Test]
        public void Test_MapToViewModel_Profile_TestMapping_Field()
        {
            Mapper.Initialize(m => m.AddProfile(new MapToViewModelProfile()));

            Book bookModel = new Book
            {
                Name = "Book1",
                Minutes = 320
            };

            Models.ViewModels.Book bookViewModel = new Models.ViewModels.Book();

            Mapper.Map(bookModel, bookViewModel);

            Assert.AreEqual(bookModel.Name, bookViewModel.Name);
            Assert.AreEqual("Book1", bookViewModel.Name);
            Assert.AreEqual("5h 20m", bookViewModel.RunningTime);
        }
    }
}
