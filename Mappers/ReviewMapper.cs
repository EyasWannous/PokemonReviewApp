using PokemonReviewApp.DTO.Review;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Mappers;

public static class ReviewMapper
{
    public static ReviewDTO ToReviewDTO(this Review review)
    {
        return new ReviewDTO
        {
            Id = review.Id,
            Title = review.Title,
            Text = review.Text,
            Rating = review.Rating,
        };
    }

    public static Review FromCreateToReview(this CreateRequestReviewDTO createRequestReviewDTO)
    {
        return new Review
        {
            Title = createRequestReviewDTO.Title,
            Text = createRequestReviewDTO.Text,
            Rating = createRequestReviewDTO.Rating,
        };
    }

    public static Review FromUpdateToReview(this UpdateRequestReviewDTO updateRequestReviewDTO)
    {
        return new Review
        {
            Title = updateRequestReviewDTO.Title,
            Text = updateRequestReviewDTO.Text,
            Rating = updateRequestReviewDTO.Rating,
        };
    }
}
