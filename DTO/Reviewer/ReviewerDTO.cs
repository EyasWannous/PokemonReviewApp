using PokemonReviewApp.DTO.Review;
using System.ComponentModel.DataAnnotations;

namespace PokemonReviewApp.DTO.Reviewer;

public class ReviewerDTO
{
    [Required]
    public int Id { get; set; }
    [Required]
    public string FirstName { get; set; } = string.Empty;
    [Required]
    public string LastName { get; set; } = string.Empty;
    public string FullName => FirstName + " " + LastName;
    public ICollection<ReviewDTO> Reviews { get; set; } = [];
}
