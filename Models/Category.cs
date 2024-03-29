using System.ComponentModel.DataAnnotations;

namespace PokemonReviewApp.Models;

public class Category
{
    [Required]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; } = string.Empty;
    public ICollection<PokemonCategory> PokemonCategories { get; set; } = [];
}
