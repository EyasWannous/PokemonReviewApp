using System.ComponentModel.DataAnnotations;

namespace PokemonReviewApp.DTO.Owner;

public class OwnerDTO
{
    [Required]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; } = string.Empty;
    [Required]
    public string GYM { get; set; } = string.Empty;
}
