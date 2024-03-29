using System.ComponentModel.DataAnnotations;

namespace PokemonReviewApp.Models;

public class Review
{
    [Required]
    public int Id { get; set; }
    [Required]
    public string Title { get; set; } = string.Empty;
    [Required]
    public string Text { get; set; } = string.Empty;
    [Required]
    public int Rating { get; set; }
    [Required]
    public int ReviewerId { get; set; }
    [Required]
    public Reviewer Reviewer { get; set; }
    [Required]
    public int PokemonId { get; set; }
    [Required]
    public Pokemon Pokemon { get; set; }
}
