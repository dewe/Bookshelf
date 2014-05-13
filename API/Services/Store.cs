using System;
using System.Collections.Generic;
using System.Linq;
using API.Models;

namespace API.Services
{
    public static class Store
    {
        private static IDictionary<string, Book> _internalStore = new Dictionary<string, Book>();

        public static IEnumerable<Book> GetAllBooks()
        {
            return _internalStore.Values.Select(ShallowCopy);
        }

        public static void Upsert(Book book)
        {
            // todo: check expected version
            _internalStore[book.Isbn] = book;

        }

        public static void InitializeWith(IEnumerable<Book> items)
        {
            _internalStore = items.ToDictionary(b => b.Isbn, ShallowCopy);
        }

        private static Book ShallowCopy(Book book)
        {
            return new Book()
            {
                Isbn = book.Isbn,
                Title = book.Title,
                Author = book.Author,
                Loaned = book.Loaned,
                Version = book.Version
            };
        }
    }

    public class ConcurrencyException : Exception
    {
    }
}