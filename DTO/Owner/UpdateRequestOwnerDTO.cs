using System.ComponentModel.DataAnnotations;

namespace PokemonReviewApp.DTO.Owner;

public class UpdateRequestOwnerDTO
{
    [Required]
    [MinLength(4, ErrorMessage = "Name must be 4 or more characters")]
    [MaxLength(64, ErrorMessage = "Name cannot be over 64 characters")]
    public string Name { get; set; } = string.Empty;
    [Required]
    [MinLength(4, ErrorMessage = "GYM must be 4 or more characters")]
    [MaxLength(64, ErrorMessage = "GYM cannot be over 64 characters")]
    public string GYM { get; set; } = string.Empty;
}
