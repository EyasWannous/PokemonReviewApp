using System.ComponentModel.DataAnnotations;

namespace PokemonReviewApp.Models;

public class PokemonCategory
{
    [Required]
    public int PokemonId { get; set; }
    [Required]
    public int CategroyId { get; set; }
    public Pokemon Pokemon { get; set; }
    public Category Category { get; set; }
}
