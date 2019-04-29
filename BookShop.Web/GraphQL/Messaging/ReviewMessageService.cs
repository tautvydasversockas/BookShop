using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using BookShop.Domain.Entities;

namespace BookShop.Web.GraphQL.Messaging
{
    public class ReviewMessageService
    {
        private readonly ISubject<ReviewAddedMessage> _messageStream =
            new ReplaySubject<ReviewAddedMessage>(1);

        public ReviewAddedMessage AddReviewAddedMessage(BookReview bookReview)
        {
            var message = new ReviewAddedMessage
            {
                BookId = bookReview.BookId,
                Title = bookReview.Title
            };
            _messageStream.OnNext(message);
            return message;
        }

        public IObservable<ReviewAddedMessage> GetMessages()
        {
            return _messageStream.AsObservable();
        }
    }
}
