using BookShop.Persistence;
using BookShop.Web.GraphQL.Types;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Web.GraphQL
{
    public class BookShopQuery : ObjectGraphType
    {
        public BookShopQuery(BookShopDbContext dbContext)
        {
            Field<ListGraphType<BookType>>(
                name: "books",
                resolve: context => dbContext.Books.ToListAsync());

            Field<BookType>(
                name: "book",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" }),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    return dbContext.Books.SingleOrDefaultAsync(b => b.Id == id);
                });
        }
    }
}
