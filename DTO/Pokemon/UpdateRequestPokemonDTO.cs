using System.ComponentModel.DataAnnotations;

namespace PokemonReviewApp.DTO.Pokemon;

public class UpdateRequestPokemonDTO
{
    [Required]
    [MinLength(4, ErrorMessage = "Name must be 4 or more characters")]
    [MaxLength(64, ErrorMessage = "Name cannot be over 64 characters")]
    public string Name { get; set; } = string.Empty;
}
