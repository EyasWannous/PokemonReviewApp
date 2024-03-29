using PokemonReviewApp.DTO.Country;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Interfaces;

public interface ICountryRepository
{
    Task<ICollection<Country>> GetCountriesAsync();
    Task<Country?> GetByIdAsync(int id);
    Task<Country?> GetByNameAsync(string name);
    Task<Country?> GetByOwnerIdAsync(int ownerId);
    Task<bool> IsExistsAsync(int id);
    Task<Country> CreateAsync(CreateRequestCountryDTO createRequestCountryDTO);
    Task<Country?> UpdateAsync(int id, UpdateRequestCountryDTO updateRequestCountryDTO);
    Task<Country?> DeleteAsync(int id);
}
