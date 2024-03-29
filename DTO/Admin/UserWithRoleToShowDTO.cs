using PokemonReviewApp.Models;

namespace PokemonReviewApp.DTO.Admin;

public class UserWithRoleToShowDTO
{
    public required User UserToShow {  get; set; }
    public IList<string> Roles { get; set; } = [];
}
