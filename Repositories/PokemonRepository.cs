using Microsoft.EntityFrameworkCore;
using PokemonReviewApp.Data;
using PokemonReviewApp.DTO.Pokemon;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Mappers;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Repositories;

public class PokemonRepository(AppDbContext context) : IPokemonRepository
{
    private readonly AppDbContext _context = context;

    public async Task<Pokemon> CreateAsync(CreateRequestPokemonDTO pokemonToCreate) // int ownerId, int categoryId, 
    {
        //var ownerOfPokemon = await _context.Owners.FirstOrDefaultAsync(owner => owner.Id == ownerId);
        //if (ownerOfPokemon is null)
        //    return null;
        
        //var categoryOfPokemon = await _context.Categories.FirstOrDefaultAsync(category => category.Id == categoryId);
        //if (categoryOfPokemon is null)
        //    return null;


        //var pokemonOwner = new PokemonOwner
        //{
        //    OwnerId = ownerId,
        //    Owner = ownerOfPokemon,
        //    Pokemon = pokemon,
        //};

        //await _context.PokemonOwners.AddAsync(pokemonOwner);

        //var pokemonCategory = new PokemonCategory
        //{
        //    CategroyId = categoryId,
        //    Category = categoryOfPokemon,
        //    Pokemon = pokemon,
        //};

        //await _context.PokemonCategroies.AddAsync(pokemonCategory);
        
        var pokemon = pokemonToCreate.FromCreateToPokemon();

        await _context.Pokemon.AddAsync(pokemon);

        await _context.SaveChangesAsync();

        return pokemon;
    }

    public async Task<Pokemon?> DeleteAsync(int id)
    {
        var pokemon = await GetByIdAsync(id);
        if (pokemon is null)
            return null;

        _context.Pokemon.Remove(pokemon);

        await _context.SaveChangesAsync();

        return pokemon;
    }

    public async Task<Pokemon?> GetByIdAsync(int id) 
        => await _context.Pokemon.FirstOrDefaultAsync(pokemon => pokemon.Id == id);

    public async Task<Pokemon?> GetByNameAsync(string name)
        => await _context.Pokemon.FirstOrDefaultAsync(pokemon => pokemon.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase));


    public async Task<double> GetPokemonRatingAsync(int id)
    {
        var reviews = await _context.Reviews.Where(review => review.Pokemon.Id == id).ToListAsync();

        if (reviews.Count == 0)
            return 0;
        
        //return ((decimal)reviews.Sum(review => review.Rating) / reviews.Count);

        return Math.Round(reviews.Average(review => review.Rating), 2);
    }

    public async Task<ICollection<Pokemon>> GetPokemonsAsync() 
        => await _context.Pokemon.ToListAsync();

    public async Task<ICollection<Pokemon>> GetPokemonsByCategoryIdAsync(int categoryId)
        => await _context.PokemonCategroies.Where(pc => pc.CategroyId == categoryId).Select(pc => pc.Pokemon).ToListAsync();

    public async Task<ICollection<Pokemon>> GetPokemonsByOwnerIdAsync(int ownerId)
        => await _context.PokemonOwners.Where(po => po.OwnerId == ownerId).Select(po => po.Pokemon).ToListAsync(); 

    public async Task<bool> IsExistsAsync(int id)
        => await _context.Pokemon.AnyAsync(p => p.Id == id);

    public async Task<Pokemon?> UpdateAsync(int id, UpdateRequestPokemonDTO updateRequestPokemonDTO)
    {
        var pokemon = await GetByIdAsync(id);
        if (pokemon is null)
            return null;

        pokemon.Name = updateRequestPokemonDTO.Name;

        await _context.SaveChangesAsync();

        return pokemon;
    }
}
