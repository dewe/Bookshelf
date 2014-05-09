using System.Collections.Generic;
using System.Web.Http;
using API.Models;

namespace API.Controllers
{
    public class BooksController : ApiController
    {
        // GET books
        public IEnumerable<Book> Get()
        {
            var bookstore = BookStore.Current;
            return bookstore.Books();
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
