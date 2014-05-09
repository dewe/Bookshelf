using System.Dynamic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API.Models;
using API.Services;
using Newtonsoft.Json.Linq;

namespace API.Controllers
{
    public class BooksController : ApiController
    {
        // GET books
        public BooksDto Get()
        {
            return new BooksDto
            {
                Books = BookStore.Current.Books()
            };
        }

        // GET books/{id}
        public string Get(int id)
        {
            return "value";
        }

        // POST books
        public void Post([FromBody]string value)
        {
        }

        // PUT books/{id}
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE books/5
        public void Delete(int id)
        {
        }
    }
}
