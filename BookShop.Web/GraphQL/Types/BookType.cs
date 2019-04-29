using BookShop.Domain.Entities;
using BookShop.Persistence;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using GraphQL.DataLoader;

namespace BookShop.Web.GraphQL.Types
{
    public class BookType : ObjectGraphType<Book>
    {
        public BookType(BookShopDbContext dbContext, IDataLoaderContextAccessor dataLoaderAccessor)
        {
            Field(t => t.Id);
            Field<BookType>("Type", "Type of the book");
            Field(t => t.Name).Description("The name of the book");
            Field(t => t.Description);
            Field(t => t.PhotoFileName);
            Field(t => t.Price);
            Field(t => t.PublishedDate);
            Field(t => t.Publisher);
            Field(t => t.Rating);
            Field(t => t.Stock);

            Field<ListGraphType<BookReviewType>>(
                name: "reviews",
                resolve: context => dataLoaderAccessor.Context.GetOrAddCollectionBatchLoader<int, BookReview>(
                        loaderKey: "GetReviewsByBookId",
                        fetchFunc: async bookIds =>
                        {
                            var reviews = await dbContext.BookReviews.Where(br => bookIds.Contains(br.BookId)).ToListAsync();
                            return reviews.ToLookup(r => r.BookId);
                        })
                        .LoadAsync(context.Source.Id));
        }
    }
}
