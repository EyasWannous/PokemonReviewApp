using System.ComponentModel.DataAnnotations;

namespace PokemonReviewApp.Models;

public class PokemonOwner
{
    [Required]
    public int PokemonId { get; set; }
    [Required]
    public int OwnerId { get; set; }
    public required Pokemon Pokemon { get; set; }
    public required Owner Owner { get; set; }
}
