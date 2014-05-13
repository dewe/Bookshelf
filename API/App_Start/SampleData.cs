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
                    Isbn = "0321125215",
                    Title = "Domain-Driven Design: Tackling Complexity in the Heart of Software",
                    Author = "Eric Evans",
                    Loaned = null
                },
                new Book
                {
                    Isbn = "0596805829",
                    Title = "REST in Practice, Hypermedia and Systems Architecture",
                    Author = "Jim Webber, Savas Parastatidis, Ian Robinson",
                    Loaned = null
                },
                new Book
                {
                    Isbn = "0670921602",
                    Title = "The Lean Startup: How Today's Entrepreneurs Use Continuous Innovation to Create Radically Successful Businesses",
                    Author = "Eric Ries",
                    Loaned = null
                },
                new Book
                {
                    Isbn = "0321601912",
                    Title = "Continuous Delivery: Reliable Software Releases through Build, Test, and Deployment Automation",
                    Author = "Jez Humble, David Farley",
                    Loaned = null
                }
            };
        }
    }
}