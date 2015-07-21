using RestSharp;

namespace BookRepo.Clients
{
    public class GoogleBooksApi
    {
        private readonly IRestClient _client = new RestClient();

        public GoogleBooksApi(string url)
        {
            _client = new RestClient(url);
        }

        public GoogleBooksApi(IRestClient client)
        {
            _client = client;
        }

        public IRestResponse Execute(string url, Method method)
        {
            RestRequest request = new RestRequest(url, method);

            return _client.Execute(request);

            //https://www.googleapis.com/books/v1/volumes/ItvZr-OV0DEC?key=AIzaSyDhHJkRg7Yv6Z4hpw0OGsuMUl_WIlWpj20
        }

        public GoogleBook GetGoogleBookApiResult(string url, Method method)
        {
            RestRequest request = new RestRequest(url, method);

            var response = _client.Execute<GoogleBook>(request);

            response.Data = MapIsbn(response.Data);

            return response.Data;
        }

        private GoogleBook MapIsbn(GoogleBook googleBook)
        {
            foreach (var identifier in googleBook.VolumeInfo.IndustryIdentifiers)
            {
                switch (identifier.Type)
                {
                    case "ISBN_10":
                        googleBook.VolumeInfo.Isbn10 = identifier.Identifier;
                        break;
                    case "ISBN_13":
                        googleBook.VolumeInfo.Isbn13 = identifier.Identifier;
                        break;

                }
            }

            return googleBook;
        }


    }
}