using System;
using System.Threading;
using API.Models;
using API.Services;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class BooksController : ApiController
    {
        [Route("books")]
        public BooksDto Get()
        {
            return new BooksDto
            {
                Books = Store.GetAllBooks()
            };
        }

        [Route("books/{isbn}")]
        public Book Get(string isbn)
        {
            var book = Store.GetAllBooks().FirstOrDefault(b => b.Isbn == isbn);
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

            book.Loaned = name;
            Store.Upsert(book);

            return Request.CreateResponse(HttpStatusCode.Created, Get(isbn));
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
