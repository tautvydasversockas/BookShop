using BookShop.Web.GraphQL.Messaging;
using GraphQL.Types;

namespace BookShop.Web.GraphQL.Types
{
    public class ReviewAddedMessageType : ObjectGraphType<ReviewAddedMessage>
    {
        public ReviewAddedMessageType()
        {
            Field(t => t.BookId);
            Field(t => t.Title);
        }
    }
}
