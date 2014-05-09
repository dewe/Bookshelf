using System.Linq;
using API.Controllers;
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

            booksController.Get().Count().ShouldBe(5);
        }
    }
}