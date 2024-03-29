using PokemonReviewApp.DTO.Review;
using PokemonReviewApp.DTO.Reviewer;
using PokemonReviewApp.Models;
using System.Collections.ObjectModel;

namespace PokemonReviewApp.Mappers;

public static class ReviewerMapper
{
    public static ReviewerDTO ToReviewerDTO(this Reviewer reviewer)
    {
        return new ReviewerDTO
        {
            Id = reviewer.Id,
            FirstName = reviewer.FirstName,
            LastName = reviewer.LastName,
            Reviews = reviewer.Reviews.Select(review => review.ToReviewDTO()).ToList(),
        };
    }

    public static Reviewer FromCreateToReviewer(this CreateRequestReviewerDTO createRequestReviewerDTO)
    {
        return new Reviewer
        {
            FirstName = createRequestReviewerDTO.FirstName,
            LastName = createRequestReviewerDTO.LastName,
        };
    }

    public static Reviewer FromUpdateToReviewer(this UpdateRequestReviewerDTO updateRequestReviewerDTO)
    {
        return new Reviewer
        {
            FirstName = updateRequestReviewerDTO.FirstName,
            LastName = updateRequestReviewerDTO.LastName,
        };
    }
}
