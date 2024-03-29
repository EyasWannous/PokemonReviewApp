using Microsoft.EntityFrameworkCore;
using PokemonReviewApp.Data;
using PokemonReviewApp.DTO.Country;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Mappers;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Repositories;

public class CountryRepository(AppDbContext context) : ICountryRepository
{
    private readonly AppDbContext _context = context;

    public async Task<Country> CreateAsync(CreateRequestCountryDTO createRequestCountryDTO)
    {
        var country = createRequestCountryDTO.FromCreateToCountry();

        await _context.Countries.AddAsync(country);

        await _context.SaveChangesAsync();

        return country;
    }

    public async Task<Country?> DeleteAsync(int id)
    {
        var country = await GetByIdAsync(id);
        if (country == null)
            return null;

        _context.Countries.Remove(country);

        await _context.SaveChangesAsync();

        return country;
    }

    public async Task<Country?> GetByIdAsync(int id)
        => await _context.Countries.FirstOrDefaultAsync(country => country.Id == id);

    public async Task<Country?> GetByNameAsync(string name)
        => await _context.Countries.FirstOrDefaultAsync(country => country.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase));

    public async Task<Country?> GetByOwnerIdAsync(int ownerId)
        => await _context.Owners.Where(owner => owner.Id == ownerId).Select(owner => owner.Country).FirstOrDefaultAsync();

    public async Task<ICollection<Country>> GetCountriesAsync()
        => await _context.Countries.ToListAsync();

    public async Task<bool> IsExistsAsync(int id)
        => await _context.Countries.AnyAsync(country => country.Id == id);

    public async Task<Country?> UpdateAsync(int id, UpdateRequestCountryDTO updateRequestCountryDTO)
    {
        var country = await GetByIdAsync(id);
        if (country == null)
            return null;

        country.Name = updateRequestCountryDTO.Name;

        await _context.SaveChangesAsync();

        return country;
    }
}
