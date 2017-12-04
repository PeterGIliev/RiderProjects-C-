using System.Collections.Generic;
using BookShop.Models;

namespace BookShop.Dto
{
    public class AuthorDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public decimal BookNumber { get; set; }

        public List<Book> Books { get; set; }
    }
}