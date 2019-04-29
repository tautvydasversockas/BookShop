using BookShop.Domain.Entities;
using BookShop.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace BookShop.Persistence.Configuration
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.Author)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.Type)
                .IsRequired()
                .HasConversion(
                    v => v.ToString(),
                    v => (BookType)Enum.Parse(typeof(BookType), v));

            builder.Property(e => e.PhotoFileName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.Price)
                .IsRequired()
                .HasColumnType("decimal(8, 2)");

            builder.Property(e => e.PublishedDate)
                .IsRequired();

            builder.Property(e => e.Publisher)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.Rating)
                .IsRequired();

            builder.Property(e => e.Stock)
                .IsRequired();
        }
    }
}
