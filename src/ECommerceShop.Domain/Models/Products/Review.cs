namespace ECommerceShop.Domain.Models.Products;

using Common;
using Exceptions;

using static ModelConstants.Review;

public class Review : Entity<int>
{
    internal Review(string username, string content, int rating)
    { 
        this.Validate(username, content, rating);
        Username = username;
        Content = content;
        Rating = rating;
    }

    public string Username { get; private set; }

    public string Content { get; private set; }

    public int Rating { get; private set; }

    private void Validate(string username, string content, int rating)
    {
        this.ValidateUsername(username);
        this.ValidateContent(content);
        this.ValidateRating(rating);
    }

    private void ValidateUsername(string username)
        => Guard.AgainstEmptyString<InvalidReviewException>(
            username,
            nameof(this.Username));

    private void ValidateContent(string content)
        => Guard.ForStringLength<InvalidReviewException>(
            content,
            MinContentLength,
            MaxContentLength,
            nameof(this.Content));

    private void ValidateRating(int rating)
        => Guard.AgainstOutOfRange<InvalidReviewException>(
            rating,
            MinRating,
            MaxRating,
            nameof(this.Rating));
}
