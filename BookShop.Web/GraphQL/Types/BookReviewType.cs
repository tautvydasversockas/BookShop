using BookShop.Domain.Entities;
using GraphQL.Types;

namespace BookShop.Web.GraphQL.Types
{
    public class BookReviewType : ObjectGraphType<BookReview>
    {
        public BookReviewType()
        {
            Field(t => t.Id);
            Field(t => t.Title);
            Field(t => t.Review);
        }
    }
}
