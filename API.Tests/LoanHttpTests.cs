using System.Linq;
using System.Net;
using System.Net.Http;
using NUnit.Framework;
using Shouldly;

namespace API.Tests
{
    [TestFixture]
    public class LoanHttpTests : InProcessHttpTests
    {
        [Test]
        public async void Put_loan_returns_201_created()
        {
            var isbn = SampleData.Books().First().Isbn;
            var url = "/books/" + isbn + "/loan";

            var response = await Client.PutAsJsonAsync(url, "name");

            response.StatusCode.ShouldBe(HttpStatusCode.Created);
        }

        [Test]
        public async void Put_loan_when_not_free_returns_403_forbidden()
        {
            var isbn = SampleData.Books().First().Isbn;
            var url = "/books/" + isbn + "/loan";
            await Client.PutAsJsonAsync(url, "Borrower 1");
            
            var response = await Client.PutAsJsonAsync(url, "Borrower 2");
            
            response.StatusCode.ShouldBe(HttpStatusCode.Forbidden);
        }

        [Test]
        public async void Delete_loan_returns_200()
        {
            var isbn = SampleData.Books().First().Isbn;
            var url = "/books/" + isbn + "/loan";
            await Client.PutAsJsonAsync(url, "name");

            var response = await Client.DeleteAsync(url);

            response.StatusCode.ShouldBe(HttpStatusCode.OK);
        }
    }
}