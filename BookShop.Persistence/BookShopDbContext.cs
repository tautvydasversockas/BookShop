using BookShop.Domain.Entities;
using BookShop.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Persistence
{
    public class BookShopDbContext : DbContext
    {
        public BookShopDbContext(DbContextOptions<BookShopDbContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<BookReview> BookReviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
            => modelBuilder.ApplyAllConfigurations();
    }
}
