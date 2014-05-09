using System.Linq;
using API.Controllers;
using API.Services;
using NUnit.Framework;
using Shouldly;

namespace API.Tests
{
    [TestFixture]
    public class BooksControllerTests
    {
        [Test]
        public void Get_books_returns_all_books()
        {
            BookStore.Current = new BookStore();
            var booksController = new BooksController();

            var books = booksController.Get().Books;

            books.Count().ShouldBe(5);
        }
    }
}