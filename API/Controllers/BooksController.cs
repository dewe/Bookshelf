using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http;
using API.Models;
using API.Services;
using Newtonsoft.Json.Linq;

namespace API.Controllers
{
    public class BooksController : ApiController
    {
        [Route("books")]
        public BooksDto Get()
        {
            return new BooksDto
            {
                Books = Store<Book>.Items()
            };
        }

        [Route("books/{isbn}")]
        public Book Get(string isbn)
        {
            var book = Store<Book>.Items().FirstOrDefault(b => b.Isbn == isbn);
            if (book == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return book;
        }

        [Route("books/{isbn}/loan")]
        public HttpResponseMessage PutLoan(string isbn, [FromBody]string name)
        {
            var book = Get(isbn);
            if (book.HasLoan())
            {
                throw new HttpResponseException(HttpStatusCode.Forbidden);
            }

            if (string.IsNullOrEmpty(name))
            {
                throw new HttpResponseException(new HttpResponseMessage((HttpStatusCode)422));
            }

            // TODO: add optimistic concurrency checks
            book.Loaned = name; 

            return Request.CreateResponse(HttpStatusCode.Created, book);
        }

        [Route("books/{isbn}/loan")]
        public Book DeleteLoan(string isbn)
        {
            var book = Get(isbn);
            if (book.HasLoan() == false)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            // TODO: add optimistic concurrency checks
            book.Loaned = null; 

            return book;
        }
    }
}
