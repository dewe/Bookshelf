using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API.Models;
using API.Services;

namespace API.Controllers
{
    public class BooksController : ApiController
    {
        [Route("books")]
        public BooksDto Get()
        {
            return new BooksDto
            {
                Books = SimpleStore<Book>.Items()
            };
        }

        [Route("books/{isbn}")]
        public Book Get(string isbn)
        {
            return SimpleStore<Book>.Items().FirstOrDefault(b => b.Isbn == isbn);
        }

        [Route("books/{isbn}/loan")]
        public HttpResponseMessage PutLoan(string isbn, [FromBody]string value)
        {
            var book = SimpleStore<Book>.Items().FirstOrDefault(b => b.Isbn == isbn);

            book.Loaned = value;

            return Request.CreateResponse(HttpStatusCode.Created, book);
        }

        // DELETE books/5
        public void Delete(int id)
        {
        }
    }
}
