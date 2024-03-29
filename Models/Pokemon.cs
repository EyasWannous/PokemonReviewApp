using System.ComponentModel.DataAnnotations;

namespace PokemonReviewApp.Models;

public class Pokemon
{
    [Required]
    public int Id { get; set; }
    [Required]
    [MaxLength(100)]
    [MinLength(2)]
    public string Name { get; set; } = string.Empty;
    [Required]
    public DateTime BirthDate { get; set; }
    public ICollection<Review> Reviews { get; set; } = [];
    public ICollection<PokemonOwner> PokemonOwners { get; set; } = [];
    public ICollection<PokemonCategory> PokemonCategories { get; set; } = [];
}
