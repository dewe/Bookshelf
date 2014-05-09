using System.Collections.Generic;
using System.Linq;
using System.Text;
using API.Models;

namespace API
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