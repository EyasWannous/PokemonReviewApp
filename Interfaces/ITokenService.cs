using PokemonReviewApp.Models;

namespace PokemonReviewApp.Interfaces;

public interface ITokenService
{
    Task<string> GetTokenAsync(string token);
    Task<string> CreateTokenAsync(User user);
}
