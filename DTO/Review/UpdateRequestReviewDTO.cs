using System.ComponentModel.DataAnnotations;

namespace PokemonReviewApp.DTO.Review;

public class UpdateRequestReviewDTO
{
    [Required]
    [MinLength(8, ErrorMessage = "Title must be 8 or more characters")]
    [MaxLength(64, ErrorMessage = "Title cannot be over 64 characters")]
    public string Title { get; set; } = string.Empty;
    [Required]
    [MinLength(4, ErrorMessage = "Text must be 4 or more characters")]
    [MaxLength(280, ErrorMessage = "Text cannot be over 280 characters")]
    public string Text { get; set; } = string.Empty;
    [Required]
    [Range(0, 10)]
    public int Rating { get; set; }
}
