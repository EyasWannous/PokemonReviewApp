using System.ComponentModel.DataAnnotations;

namespace PokemonReviewApp.DTO.Review;

public class ReviewDTO
{
    [Required]
    public int Id { get; set; }
    [Required]
    public string Title { get; set; } = string.Empty;
    [Required]
    public string Text { get; set; } = string.Empty;
    [Required]
    public int Rating { get; set; }
}
