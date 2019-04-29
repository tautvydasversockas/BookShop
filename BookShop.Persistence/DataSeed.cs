using BookShop.Domain.Entities;
using BookShop.Domain.Enums;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BookShop.Persistence
{
    public static class DataSeed
    {
        public static async Task SeedAsync(this BookShopDbContext dbContext)
        {
            await dbContext.SeedBooksAsync();
            await dbContext.SeedBookReviewsAsync();
        }

        private static async Task SeedBooksAsync(this BookShopDbContext dbContext)
        {
            if (dbContext.Books.Any())
                return;

            var books = new[]
            {
                new Book
                {
                    Type = BookType.Paperback,
                    Name = "A Financial Bestiary",
                    Author = "Ramin Charles Nakisa",
                    Publisher = "Chesham Bois Publishing",
                    Description = "This is an applied book, using the bare minimum of mathematics to give a good understanding of finance. It is ideal for people just starting out in their financial career or those who have some financial experience who want to broaden and refresh their knowledge. ",
                    Price = 20,
                    Rating = 4,
                    Stock = 12,
                    PhotoFileName = "afinancialbestiary1.jpg",
                    PublishedDate = new DateTime(2010, 9, 22)
                },
                new Book
                {
                    Type = BookType.Hardcover,
                    Name = "A Financial Bestiary",
                    Author = "Ramin Charles Nakisa",
                    Publisher = "Chesham Bois Publishing",
                    Description = "This is an applied book, using the bare minimum of mathematics to give a good understanding of finance. It is ideal for people just starting out in their financial career or those who have some financial experience who want to broaden and refresh their knowledge. ",
                    Price = 33.99m,
                    Rating = 5,
                    Stock = 89,
                    PhotoFileName = "afinancialbestiary1.jpg",
                    PublishedDate = new DateTime(2010, 9, 22)
                },
                new Book
                {
                    Type = BookType.Audio,
                    Name = "Think and Grow Rich",
                    Author = "Napoleon Hill",
                    Publisher = "Chesham Bois Publishing",
                    Description = "'Think and Grow Rich' is a motivational personal development and selfhelp audiobook written by Napoleon Hill and inspired by a suggestion from Scottish-American businessman Andrew Carnegie.",
                    Price = 6.99m,
                    Rating = 5,
                    Stock = 7,
                    PhotoFileName = "thinkandgrowrich1.jpg",
                    PublishedDate = new DateTime(2017, 9, 1)
                }
            };

            await dbContext.Books.AddRangeAsync(books);
            await dbContext.SaveChangesAsync();
        }

        private static async Task SeedBookReviewsAsync(this BookShopDbContext dbContext)
        {
            if (dbContext.BookReviews.Any())
                return;

            var bookReviews = new[]
            {
                new BookReview
                {
                    BookId = 1,
                    Title = "Good for making money",
                    Review = "A good book for understanding the finance world"
                },
                new BookReview
                {
                    BookId = 1,
                    Title = "Changed my life",
                    Review = "After reading this book I am a millionaire now."
                },
                new BookReview
                {
                    BookId = 2,
                    Title = "Good quality",
                    Review = "Very good publishing quality. Very interesting book to read as well."
                },
                new BookReview
                {
                    BookId = 3,
                    Title = "A must listen",
                    Review = "Best 10 listening hours spent ever."
                }
            };

            await dbContext.BookReviews.AddRangeAsync(bookReviews);
            await dbContext.SaveChangesAsync();
        }
    }
}