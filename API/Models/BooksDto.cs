using System.Collections.Generic;

namespace API.Models
{
    public class BooksDto
    {
        public IEnumerable<Book> Books { get; set; }
    }
}