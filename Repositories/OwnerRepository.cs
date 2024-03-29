using Microsoft.EntityFrameworkCore;
using PokemonReviewApp.Data;
using PokemonReviewApp.DTO.Owner;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Mappers;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Repositories;

public class OwnerRepository(AppDbContext context) : IOwnerRepository
{
    private readonly AppDbContext _context = context;

    public async Task<Owner?> CreateAsync(int countryId,CreateRequestOwnerDTO createRequestOwnerDTO)
    {
        var country = await _context.Countries.FirstOrDefaultAsync(country => country.Id == countryId);
        if (country is null)
            return null;

        var owner = createRequestOwnerDTO.FromCreateToOwner();
        owner.CountryId = countryId;

        await _context.Owners.AddAsync(owner);

        await _context.SaveChangesAsync();

        return owner;
    }

    public async Task<Owner?> DeleteAsync(int id)
    {
        var owner = await GetByIdAsync(id);
        if (owner is null)
            return null;

        _context.Owners.Remove(owner);

        await _context.SaveChangesAsync();

        return owner;
    }

    public async Task<Owner?> GetByIdAsync(int id)
        => await _context.Owners.FirstOrDefaultAsync(owner => owner.Id == id);

    public async Task<Owner?> GetByNameAsync(string name)
        => await _context.Owners.FirstOrDefaultAsync(owner => owner.Name == name);

    public async Task<ICollection<Owner>> GetOwnersAsync()
        => await _context.Owners.ToListAsync();

    public async Task<ICollection<Owner>> GetOwnersByCountryId(int countryId)
        => await _context.Owners.Where(owner => owner.CountryId == countryId).ToListAsync();

    public async Task<bool> IsExistsAsync(int id)
        => await _context.Owners.AnyAsync(owner => owner.Id == id);

    public async Task<Owner?> UpdateAsync(int id, UpdateRequestOwnerDTO updateRequestOwnerDTO)
    {
        var owner = await GetByIdAsync(id);
        if (owner is null) 
            return null;

        owner.Name = updateRequestOwnerDTO.Name;
        owner.GYM = updateRequestOwnerDTO.GYM;

        await _context.SaveChangesAsync();

        return owner;
    }
}
