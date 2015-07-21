using BookRepo.Clients;
using NUnit.Framework;
using RestSharp;

namespace BookRepo.UnitTests.Clients
{
    [TestFixture]
    public class GoogleBooksApiTester
    {
        [Test]
        public void GoogleBooksApi_IntegrationTests()
        {
            GoogleBooksApi api =
                new GoogleBooksApi(
                    "https://www.googleapis.com");

            //var result = api.Execute("books/v1/volumes/ItvZr-OV0DEC?key=AIzaSyDhHJkRg7Yv6Z4hpw0OGsuMUl_WIlWpj20", Method.GET);
            var googleBook = api.GetGoogleBookApiResult("books/v1/volumes/ItvZr-OV0DEC?key=AIzaSyDhHJkRg7Yv6Z4hpw0OGsuMUl_WIlWpj20", Method.GET);

            Assert.AreEqual("books#volume", googleBook.Kind);   
            Assert.AreEqual("The Last Man", googleBook.VolumeInfo.Title);
            Assert.AreEqual("Simon and Schuster", googleBook.VolumeInfo.Publisher);
            Assert.AreEqual("9781439100530", googleBook.VolumeInfo.IndustryIdentifiers[1].Identifier);
            Assert.AreEqual("9781439100530", googleBook.VolumeInfo.Isbn13);
            Assert.AreEqual("1439100535", googleBook.VolumeInfo.Isbn10);
        }
    }
}
