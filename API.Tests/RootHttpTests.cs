using System.Net;
using NUnit.Framework;
using Shouldly;

namespace API.Tests
{
    [TestFixture]
    public class RootHttpTests : InProcessHttpTests
    {
        [Test]
        public async void Get_root_returns_200_ok()
        {
            var response = await Client.GetAsync("/");
            response.StatusCode.ShouldBe(HttpStatusCode.OK);
        }
   }
}