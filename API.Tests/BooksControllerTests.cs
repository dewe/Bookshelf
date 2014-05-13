using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using API.Controllers;
using API.Models;
using API.Services;
using NUnit.Framework;
using Shouldly;

namespace API.Tests
{
    [TestFixture]
    public class BooksControllerTests
    {
        private BooksController _booksController;

        [Test]
        public void Get_books_returns_all_books()
        {
            var books = _booksController.Get().Books;
            books.Count().ShouldBe(5);
        }

        [Test]
        public void Get_book_by_Isbn_return_single_book()
        {
            var book = _booksController.Get("1234567890");
            book.Isbn.ShouldBe("1234567890");
        }

        [Test]
        public void Loan_free_book_assigns_borrower_to_book()
        {
            Book book;
            var response = _booksController.PutLoan("1234567890", "borrowers name");
            response.TryGetContentValue(out book);
            book.Loaned.ShouldBe("borrowers name");
        }

        [Test]
        public void Return_book_unassign_borrower()
        {
            _booksController.PutLoan("1234567890", "borrowers name");
            var book = _booksController.DeleteLoan("1234567890");
            book.Loaned.ShouldBe(null);
        }

        [Test]
        public void Loan_concurrently_throws_exception()
        {
            var loan1 = Task.Factory.StartNew(() => _booksController.PutLoan("1234567890", "borrower1"));
            var loan2 = Task.Factory.StartNew(() => _booksController.PutLoan("1234567890", "borrower2"));

            try
            {
                Task.WaitAll(loan1, loan2);
            }
            catch (AggregateException exception)
            {
                exception.InnerExceptions.Count().ShouldBe(1);
                exception.InnerExceptions[0].ShouldBeOfType<ConcurrencyException>();
            }
        }

        [SetUp]
        public void SetUp()
        {
            Store.InitializeWith(new Book[]
            {
                new Book { Isbn = "0000000001" },
                new Book { Isbn = "0000000002" },
                new Book { Isbn = "0000000003" },
                new Book { Isbn = "0000000004" },
                new Book { Isbn = "1234567890" }
            });

            _booksController = new BooksController();
            _booksController.Request = new HttpRequestMessage();
            _booksController.Request.SetConfiguration(new HttpConfiguration());
        }
    }
}