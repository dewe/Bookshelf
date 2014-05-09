using System.Dynamic;
using System.Linq;
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
                Books = FakeBookStore.Books()
            };
        }

        // GET books/{isbn}
        public Book Get(string isbn)
        {
            return FakeBookStore.Books().FirstOrDefault(b => b.Isbn == isbn);
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
