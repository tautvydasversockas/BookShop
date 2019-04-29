using BookShop.Web.GraphQL.Messaging;
using BookShop.Web.GraphQL.Types;
using GraphQL.Resolvers;
using GraphQL.Types;

namespace BookShop.Web.GraphQL
{
    public class BookShopSubscription : ObjectGraphType
    {
        public BookShopSubscription(ReviewMessageService reviewMessageService)
        {
            Name = "Subscription";
            AddField(new EventStreamFieldType
            {
                Name = "reviewAdded",
                Type = typeof(ReviewAddedMessageType),
                Resolver = new FuncFieldResolver<ReviewAddedMessage>(c =>
                    c.Source as ReviewAddedMessage),
                Subscriber = new EventStreamResolver<ReviewAddedMessage>(c =>
                    reviewMessageService.GetMessages())
            });
        }
    }
}
