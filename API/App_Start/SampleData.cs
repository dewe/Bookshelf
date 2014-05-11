using System.Collections.Generic;
using API.Models;

namespace API
{
    public static class SampleData
    {
        public static IEnumerable<Book> Books()
        {
            return new[]
            {
                new Book
                {
                    Title = "Domain-Driven Design: Tackling Complexity in the Heart of Software",
                    Author = "Eric Evans",
                    Isbn = "0321125215"
                },
                new Book
                {
                    Title = "REST in Practice, Hypermedia and Systems Architecture",
                    Author = "Jim Webber, Savas Parastatidis, Ian Robinson",
                    Isbn = "0596805829"
                },
                new Book
                {
                    Title = "The Lean Startup: How Today's Entrepreneurs Use Continuous Innovation to Create Radically Successful Businesses",
                    Author = "Eric Ries",
                    Isbn = "0670921602"
                },
                new Book
                {
                    Title = "Continuous Delivery: Reliable Software Releases through Build, Test, and Deployment Automation",
                    Author = "Jez Humble, David Farley",
                    Isbn = "0321601912"
                }
            };
        }
    }
}