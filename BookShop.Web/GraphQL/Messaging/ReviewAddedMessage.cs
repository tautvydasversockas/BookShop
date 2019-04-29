namespace BookShop.Web.GraphQL.Messaging
{
    public class ReviewAddedMessage
    {
        public int BookId { get; set; }
        public string Title { get; set; }
    }
}