namespace API.Models
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Isbn { get; set; }
        public string Loaned { get; set; }
        public int Version { get; set; }

        public virtual bool HasLoan()
        {
            return string.IsNullOrEmpty(Loaned) != true;
        }
    }
}