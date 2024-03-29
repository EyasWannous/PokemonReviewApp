using System.ComponentModel.DataAnnotations;

namespace PokemonReviewApp.Models;

public class Owner
{
    [Required]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; } = string.Empty;
    [Required]
    public string GYM { get; set; } = string.Empty;
    public int CountryId { get; set; }
    public Country Country { get; set; }
    public ICollection<PokemonOwner> PokemonOwners { get; set; } = [];
}
