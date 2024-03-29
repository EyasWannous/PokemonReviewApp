using System.ComponentModel.DataAnnotations;

namespace PokemonReviewApp.DTO.Account;

public class RegisterDTO
{
    [Required]
    [MinLength(3, ErrorMessage = "Username should be 3 or more charchters")]
    public required string UserName { get; set; }
    [Required]
    [EmailAddress]
    public required string Email { get; set; }
    [Required]
    [MinLength(8, ErrorMessage = "Password should be 8 or more charchters")]
    public required string Password { get; set; }
}
