using System;
using System.Net.Http;
using System.Web.Http;
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
            HttpServer inProcessServer = new HttpServer(config);

            Client = new HttpClient(inProcessServer);
            Client.BaseAddress = new Uri("http://in.memory.host");
        }
    }
}