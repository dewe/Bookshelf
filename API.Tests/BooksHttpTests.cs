using System.Linq;
using System.Net;
using NUnit.Framework;
using Shouldly;

namespace API.Tests
{
    [TestFixture]
    public class BooksHttpTests : InProcessHttpTests
    {
        [Test]
        public async void Get_books_returns_200_ok()
        {
            var response = await Client.GetAsync("/books");
            response.StatusCode.ShouldBe(HttpStatusCode.OK);
        }

        [Test]
        public async void Get_books_returns_media_type_json()
        {
            var response = await Client.GetAsync("/books");
            response.Content.Headers.ContentType.MediaType.ShouldBe("application/json");
        }

        [Test]
        public async void Get_single_book_returns_200_ok()
        {
            var isbn = SampleData.Books().First().Isbn;
            var url = "/books/" + isbn;

            var response = await Client.GetAsync(url);
            response.StatusCode.ShouldBe(HttpStatusCode.OK);
        }

        [Test]
        public async void Get_non_existing_book_returns_404_not_found()
        {
            var response = await Client.GetAsync("/books/0000000000");
            response.StatusCode.ShouldBe(HttpStatusCode.NotFound);
        }
    }
}