using Mus_ab.Helpers.Reviews;
using Mus_ab.Interfaces;
using Mus_ab.Models;
using Mus_ab.Models.users;

namespace Mus_ab.Services;

public class ReviewService : IReviewService
{
    ReviewReader ReviewReader = new ReviewReader();
    ReviewWriter ReviewWriter = new ReviewWriter();

    List<Review> reviews = new List<Review>();
    public async ValueTask<Review> CreateAsync(Review review)
    {
        reviews = ReviewReader.ReadReviews();
        review.Id = reviews.Count == 0 ? 1 : reviews.Last().Id + 1;
        reviews.Add(review);
        ReviewWriter.Main(reviews);
        return review;
    }

    public async ValueTask<bool> DeleteAsync(int id)
    {
        reviews = ReviewReader.ReadReviews();
        var exist= reviews.FirstOrDefault(x => x.Id == id);
        if (exist is null)
        {
            throw new Exception("Review is not found");
        }
        reviews.Remove(exist);
        ReviewWriter.Main(reviews);
        return true;
    }

    public async ValueTask<List<Review>> GetAllReviews()
    {
        reviews = ReviewReader.ReadReviews();
        return reviews;
    }

    public async ValueTask<List<Review>> GetReviewByBarberId(int barberId)
    {
        reviews = ReviewReader.ReadReviews();
        var exist = reviews.Where(x => x.BarberId == barberId).ToList();
        return exist;
    }

    public async ValueTask<Review> UpdateAsync(int id, Review review)
    {
        reviews = ReviewReader.ReadReviews();
        var exist = reviews.FirstOrDefault(x => x.Id == id);
        if (exist is null)
        {
            throw new Exception("Review is not found");
        }
        exist.Message = review.Message;
        exist.BarberId = review.BarberId;
        exist.Message=review.Message;
        exist.Id = id;
        ReviewWriter.Main(reviews);
        return exist;
    }
}
