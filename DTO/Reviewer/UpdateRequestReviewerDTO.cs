using System.ComponentModel.DataAnnotations;

namespace PokemonReviewApp.DTO.Reviewer;

public class UpdateRequestReviewerDTO
{
    [Required]
    [MinLength(1, ErrorMessage = "FirstName must be 1 or more characters")]
    [MaxLength(64, ErrorMessage = "FirstName cannot be over 64 characters")]
    public string FirstName { get; set; } = string.Empty;
    [Required]
    [MinLength(1, ErrorMessage = "LastName must be 1 or more characters")]
    [MaxLength(64, ErrorMessage = "LastName cannot be over 64 characters")]
    public string LastName { get; set; } = string.Empty;
}
