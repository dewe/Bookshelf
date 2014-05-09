﻿using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        [SetUp]
        public void SetUp()
        {
            var books = new List<Book>();
            books.AddRange(Enumerable.Repeat(new Book(), 4));
            books.Add(new Book { Isbn = "1234567890" });
            FakeBookStore.SetAll(books);

            _booksController = new BooksController();
        }

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

    }
}