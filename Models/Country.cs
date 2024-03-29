using System.ComponentModel.DataAnnotations;

namespace PokemonReviewApp.Models;

public class Country
{
    [Required]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; } = string.Empty;
    public ICollection<Owner> Owners { get; set; } = [];
}
