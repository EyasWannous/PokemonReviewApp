using Microsoft.EntityFrameworkCore;
using PokemonReviewApp.Data;
using PokemonReviewApp.DTO.Review;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Mappers;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Repositories;

public class ReviewRepository(AppDbContext context) : IReviewRepository
{
    private readonly AppDbContext _context = context;

    public async Task<Review?> CreateAsync(int pokemonId ,int reviewerId, CreateRequestReviewDTO createRequestReviewDTO)
    {
        var reviewer = await _context.Reviewers.FirstOrDefaultAsync(reviewer => reviewer.Id == reviewerId);
        if (reviewer is null)
            return null;

        var pokemon = await _context.Pokemon.FirstOrDefaultAsync(pokemon => pokemon.Id == pokemonId);
        if (pokemon is null)
            return null;

        var review = createRequestReviewDTO.FromCreateToReview();
        review.ReviewerId = reviewerId;
        review.PokemonId = pokemonId;
        review.Reviewer = reviewer;
        review.Pokemon = pokemon;

        await _context.Reviews.AddAsync(review);

        await _context.SaveChangesAsync();

        return review;
    }

    public async Task<Review?> DeleteAsync(int id)
    {
        var review = await GetByIdAsync(id);
        if (review is null) 
            return null;

        _context.Reviews.Remove(review);

        await _context.SaveChangesAsync();

        return review;
    }

    public async Task<Review?> GetByIdAsync(int id)
        => await _context.Reviews.FirstOrDefaultAsync(review => review.Id == id);

    public async Task<ICollection<Review>> GetReviewsAsync()
        => await _context.Reviews.ToListAsync();

    public async Task<ICollection<Review>> GetReviewsByPokemonIdAsync(int pokemonId)
        => await _context.Reviews.Where(review => review.PokemonId == pokemonId).ToListAsync();

    public async Task<bool> IsExistsAsync(int id)
        => await _context.Reviews.AnyAsync(review => review.Id == id);

    public async Task<Review?> UpdateAsync(int id, UpdateRequestReviewDTO updateRequestReviewDTO)
    {
        var review = await GetByIdAsync(id);
        if (review is null)
            return null;

        review.Title = updateRequestReviewDTO.Title;
        review.Text = updateRequestReviewDTO.Text;
        review.Rating = updateRequestReviewDTO.Rating;

        await _context.SaveChangesAsync();

        return review;
    }
}
