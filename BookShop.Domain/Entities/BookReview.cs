namespace BookShop.Domain.Entities
{
    public class BookReview
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
        public string Title { get; set; }
        public string Review { get; set; }
    }
}
