using BookShop.Domain.Enums;
using System;

namespace BookShop.Domain.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public BookType Type { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string Publisher { get; set; }
        public decimal Price { get; set; }
        public DateTime PublishedDate { get; set; }
        public int Stock { get; set; }
        public int Rating { get; set; }
        public string PhotoFileName { get; set; }
    }
}
