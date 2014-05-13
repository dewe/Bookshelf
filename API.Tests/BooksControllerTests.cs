using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

        [SetUp]
        public void SetUp()
        {
            var books = new List<Book>();
            books.AddRange(Enumerable.Repeat(new Book(), 4));
            books.Add(new Book { Isbn = "1234567890" });
            Store<Book>.SetItems(books);

            _booksController = new BooksController();
            _booksController.Request = new HttpRequestMessage();
            _booksController.Request.SetConfiguration(new HttpConfiguration());
        }
    }
}