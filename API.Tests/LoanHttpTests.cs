using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API.Models;
using API.Services;
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
    }
}