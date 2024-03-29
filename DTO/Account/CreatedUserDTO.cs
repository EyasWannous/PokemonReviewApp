using System.ComponentModel.DataAnnotations;

namespace PokemonReviewApp.DTO.Account;

public class CreatedUserDTO
{
    [Required]
    [MinLength(3, ErrorMessage = "Username should be 3 or more charchters")]
    public string UserName { get; set; } = string.Empty;
    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;
    [Required]
    public string Token { get; set; } = string.Empty;
}
