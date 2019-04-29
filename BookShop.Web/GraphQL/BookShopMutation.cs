using BookShop.Domain.Entities;
using BookShop.Persistence;
using BookShop.Web.GraphQL.Messaging;
using BookShop.Web.GraphQL.Types;
using GraphQL.Types;

namespace BookShop.Web.GraphQL
{
    public class BookShopMutation : ObjectGraphType
    {
        public BookShopMutation(BookShopDbContext dbContext, ReviewMessageService reviewMessageService)
        {
            FieldAsync<BookReviewType>(
                name: "createReview",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<BookReviewInputType>> {Name = "review"}),
                resolve: async context =>
                {
                    var review = context.GetArgument<BookReview>("review");
                    return await context.TryAsyncResolve(async _ =>
                    {
                        await dbContext.BookReviews.AddAsync(review);
                        await dbContext.SaveChangesAsync();
                        reviewMessageService.AddReviewAddedMessage(review);
                        return review;
                    });
                });
        }
    }
}
