using API.Models;
using API.Services;
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
            if (!Store.Exist(isbn))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return Store.GetBook(isbn);
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

            book.Loaned = null; 
            Store.Upsert(book);

            return Get(isbn);
        }
    }
}
