using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using API.Models;

namespace API.Services
{
    public static class Store
    {
        private static IDictionary<string, Book> _internalStore = new Dictionary<string, Book>();

        public static void InitializeWith(IEnumerable<Book> items)
        {
            _internalStore = items.ToDictionary(b => b.Isbn, ShallowCopy);
        }

        public static IEnumerable<Book> GetAllBooks()
        {
            return _internalStore.Values.Select(ShallowCopy);
        }

        public static void Upsert(Book book)
        {
            lock (_internalStore)
            {
                var current = _internalStore[book.Isbn];
                if (book.Version != current.Version)
                {
                    throw new ConcurrencyException();
                }

                var copy = IncreaseVersion(book);
                _internalStore[book.Isbn] = copy;
            }
        }

        private static Book IncreaseVersion(Book book)
        {
            var copy = ShallowCopy(book);
            copy.Version = book.Version + 1;
            return copy;
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