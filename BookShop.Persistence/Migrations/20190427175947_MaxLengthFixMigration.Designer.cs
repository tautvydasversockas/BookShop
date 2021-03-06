﻿// <auto-generated />
using System;
using BookShop.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BookShop.Persistence.Migrations
{
    [DbContext(typeof(BookShopDbContext))]
    [Migration("20190427175947_MaxLengthFixMigration")]
    partial class MaxLengthFixMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BookShop.Domain.Entities.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Author");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<string>("PhotoFileName");

                    b.Property<decimal>("Price");

                    b.Property<DateTime>("PublishedDate");

                    b.Property<string>("Publisher");

                    b.Property<int>("Rating");

                    b.Property<int>("Stock");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("BookShop.Domain.Entities.BookReview", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BookId");

                    b.Property<string>("Review");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.ToTable("BookReviews");
                });

            modelBuilder.Entity("BookShop.Domain.Entities.BookReview", b =>
                {
                    b.HasOne("BookShop.Domain.Entities.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
