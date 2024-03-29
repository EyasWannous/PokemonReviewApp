using PokemonReviewApp.DTO.Owner;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Interfaces;

public interface IOwnerRepository
{
    Task<ICollection<Owner>> GetOwnersAsync();
    Task<ICollection<Owner>> GetOwnersByCountryId(int countryId);
    Task<Owner?> GetByIdAsync(int id);
    Task<Owner?> GetByNameAsync(string name);
    Task<bool> IsExistsAsync(int id);
    Task<Owner?> CreateAsync(int countryId, CreateRequestOwnerDTO createRequestOwnerDTO);
    Task<Owner?> UpdateAsync(int id, UpdateRequestOwnerDTO updateRequestOwnerDTO);
    Task<Owner?> DeleteAsync(int id);
}
