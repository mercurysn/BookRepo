using AutoMapper;
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


    }
}
