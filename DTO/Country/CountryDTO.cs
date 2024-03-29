using System.ComponentModel.DataAnnotations;

namespace PokemonReviewApp.DTO.Country;

public class CountryDTO
{
    [Required]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; } = string.Empty;
}
