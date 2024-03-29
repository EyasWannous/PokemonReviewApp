using System.ComponentModel.DataAnnotations;

namespace PokemonReviewApp.DTO.Account;

public class LoginUserDTO
{
    [Required]
    [EmailAddress]
    public required string Email { get; set; }
    [Required]
    [MinLength(8, ErrorMessage = "Password should be 8 or more charchters")]
    public required string Password { get; set; }
}
