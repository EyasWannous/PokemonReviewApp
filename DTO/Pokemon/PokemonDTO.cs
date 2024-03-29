using PokemonReviewApp.Models;
using System.ComponentModel.DataAnnotations;

namespace PokemonReviewApp.DTO.Pokemon;

public class PokemonDTO
{
    [Required]
    public int Id { get; set; }
    [Required]
    [MaxLength(100)]
    [MinLength(2)]
    public string Name { get; set; } = string.Empty;
    [Required]
    public DateTime BirthDate { get; set; }
}
