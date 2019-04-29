using GraphQL;
using GraphQL.Types;

namespace BookShop.Web.GraphQL
{
    public class BookShopSchema : Schema
    {
        public BookShopSchema(IDependencyResolver resolver)
            : base(resolver)
        {
            Query = resolver.Resolve<BookShopQuery>();
            Mutation = resolver.Resolve<BookShopMutation>();
            Subscription = resolver.Resolve<BookShopSubscription>();
        }
    }
}
