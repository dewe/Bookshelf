using System.Collections.Generic;
using System.Linq;
using API.Models;

namespace API.Services
{
    public class BookStore
    {
        public static BookStore Current { get; set; }

        public IEnumerable<Book> Books()
        {
            return Enumerable.Repeat(new Book(), 5);
        }
    }
}