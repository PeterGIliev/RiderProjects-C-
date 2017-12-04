using System;

namespace BookShop.Dto
{
    public class BookDto
    {
        public string Title { get; set; }

        public int Copies { get; set; }

        public decimal Price { get; set; }

        public DateTime ReleaseDate { get; set; }
    }
}