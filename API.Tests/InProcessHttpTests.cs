using System;
using System.Net.Http;
using System.Web.Http;
using API.Models;
using API.Services;
using NUnit.Framework;

namespace API.Tests
{
    public class InProcessHttpTests
    {
        protected HttpClient Client;

        [TestFixtureSetUp]
        public void StartHost()
        {
            var config = new HttpConfiguration();
            WebApiConfig.Register(config);

            Client = new HttpClient(new HttpServer(config));
            Client.BaseAddress = new Uri("http://in.memory.host");
        }

        [SetUp]
        public void SetUp()
        {
            Store<Book>.SetItems(SampleData.Books());
        }
    }
}