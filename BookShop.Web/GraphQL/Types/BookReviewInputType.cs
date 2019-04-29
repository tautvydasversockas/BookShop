using GraphQL.Types;

namespace BookShop.Web.GraphQL.Types
{
    public class BookReviewInputType : InputObjectGraphType
    {
        public BookReviewInputType()
        {
            Name = "reviewInput";
            Field<NonNullGraphType<StringGraphType>>("title");
            Field<NonNullGraphType<StringGraphType>>("review");
            Field<NonNullGraphType<IntGraphType>>("bookId");
        }
    }
}
