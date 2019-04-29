using GraphQL.Types;

namespace BookShop.Web.GraphQL.Types
{
    public class BookTypeEnumType : EnumerationGraphType<Domain.Enums.BookType>
    {
        public BookTypeEnumType()
        {
            Name = "Type";
            Description = "Type of the book";
        }
    }
}
