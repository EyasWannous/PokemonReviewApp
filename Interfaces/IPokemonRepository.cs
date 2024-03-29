using PokemonReviewApp.DTO.Pokemon;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Interfaces;

public interface IPokemonRepository
{
    Task<ICollection<Pokemon>> GetPokemonsAsync();
    Task<ICollection<Pokemon>> GetPokemonsByCategoryIdAsync(int categoryId);
    Task<ICollection<Pokemon>> GetPokemonsByOwnerIdAsync(int ownerId);
    Task<Pokemon?> GetByIdAsync(int id);
    Task<Pokemon?> GetByNameAsync(string name);
    Task<double> GetPokemonRatingAsync(int id);
    Task<bool> IsExistsAsync(int id);
    Task<Pokemon?> DeleteAsync(int id);
    Task<Pokemon> CreateAsync(CreateRequestPokemonDTO pokemonToCreate); // int ownerId, int categoryId,
    Task<Pokemon?> UpdateAsync(int id, UpdateRequestPokemonDTO updateRequestPokemonDTO);
}