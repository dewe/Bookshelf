using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NUnit.Framework;
using Shouldly;

namespace API.Tests
{
    [TestFixture]
    public class HttpIntegrationTests
    {
        private HttpServer _handler;
        private HttpClient _client;

        [TestFixtureSetUp]
        public void StartHost()
        {
            var config = new HttpConfiguration();
            WebApiConfig.Register(config);
            _handler = new HttpServer(config);
            _client = new HttpClient(_handler);
        }

        [Test]
        public async void Get_books_returns_200()
        {
            var response = await _client.GetAsync("http://in.memory.host/books");
            
            response.StatusCode.ShouldBe(HttpStatusCode.OK);
        }

        [Test]
        public async void Get_books_returns_media_type_json()
        {
            var response = await _client.GetAsync("http://in.memory.host/books");

            response.Content.Headers.ContentType.MediaType.ShouldBe("application/json");
        }
    }
}