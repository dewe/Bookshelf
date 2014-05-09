using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class BooksController : ApiController
    {
        // GET books
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET books/5
        public string Get(int id)
        {
            return "value";
        }

        // POST books
        public void Post([FromBody]string value)
        {
        }

        // PUT books/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE books/5
        public void Delete(int id)
        {
        }
    }
}
