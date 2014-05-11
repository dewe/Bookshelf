using System;
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
        [Route("books")]
        public BooksDto Get()
        {
            return new BooksDto
            {
                Books = FakeBookStore.Books()
            };
        }

        [Route("books/{isbn}")]
        public Book Get(string isbn)
        {
            return FakeBookStore.Books().FirstOrDefault(b => b.Isbn == isbn);
        }

        [Route("books/{isbn}/loan")]
        public HttpResponseMessage PutLoan(string isbn, [FromBody]string value)
        {
            var book = FakeBookStore.Books().FirstOrDefault(b => b.Isbn == isbn);

            book.Loaned = value;

            return Request.CreateResponse(HttpStatusCode.Created, book);
        }

        // DELETE books/5
        public void Delete(int id)
        {
        }
    }
}
