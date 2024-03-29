using PokemonReviewApp.DTO.Review;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Interfaces;

public interface IReviewRepository
{
    Task<ICollection<Review>> GetReviewsAsync();
    Task<ICollection<Review>> GetReviewsByPokemonIdAsync(int pokemonId);
    Task<Review?> GetByIdAsync(int id);
    Task<bool> IsExistsAsync(int id);
    Task<Review?> CreateAsync(int pokemonId, int reviewerId, CreateRequestReviewDTO createRequestReviewDTO);
    Task<Review?> UpdateAsync(int id, UpdateRequestReviewDTO updateRequestReviewDTO);
    Task<Review?> DeleteAsync(int id);
}
