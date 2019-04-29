using BookShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookShop.Persistence.Configuration
{
    public class BookReviewConfiguration : IEntityTypeConfiguration<BookReview>
    {
        public void Configure(EntityTypeBuilder<BookReview> builder)
        {
            builder.HasKey(e => e.Id);

            builder
               .HasOne(e => e.Book)
               .WithMany()
               .HasForeignKey(p => p.BookId);

            builder.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(e => e.Review)
                .IsRequired()
                .HasMaxLength(200);
        }
    }
}
