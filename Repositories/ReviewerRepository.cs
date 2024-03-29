using Microsoft.EntityFrameworkCore;
using PokemonReviewApp.Data;
using PokemonReviewApp.DTO.Reviewer;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Mappers;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Repositories;

public class ReviewerRepository(AppDbContext context) : IReviewerRepository
{
    private readonly AppDbContext _context = context;

    public async Task<Reviewer> CreateAsync(CreateRequestReviewerDTO createRequestReviewerDTO)
    {
        var reviewer = createRequestReviewerDTO.FromCreateToReviewer();

        await _context.Reviewers.AddAsync(reviewer);

        await _context.SaveChangesAsync();

        return reviewer;
    }

    public async Task<Reviewer?> DeleteAsync(int id)
    {
        var reviewer = await _context.Reviewers.FindAsync(id);
        if (reviewer is null)
            return null;

        _context.Reviewers.Remove(reviewer);

        await _context.SaveChangesAsync();

        return reviewer;
    }

    public async Task<Reviewer?> GetByFullNameAsync(string name)
    {
        var fullName = name.Trim().Split(" ");
        return await _context.Reviewers
            .FirstOrDefaultAsync(reviewer
                => reviewer.FirstName.ToLower() == fullName[0].ToLower()
                && reviewer.LastName.ToLower() == fullName[1].ToLower()
            );
    }
    //=> await _context.Reviewers.FirstOrDefaultAsync(reviewer => reviewer.FullName.ToLower() == name.ToLower());

    public async Task<Reviewer?> GetByIdAsync(int id)
        => await _context.Reviewers.Where(reviewer => reviewer.Id == id).Include(reviewer => reviewer.Reviews).FirstOrDefaultAsync();

    public async Task<ICollection<Reviewer>> GetReviewersAsync()
        => await _context.Reviewers.ToListAsync();

    public async Task<bool> IsExistsAsync(int id)
        => await _context.Reviewers.AnyAsync(reviewer => reviewer.Id == id);

    public async Task<Reviewer?> UpdateAsync(int id, UpdateRequestReviewerDTO updateRequestReviewerDTO)
    {
        var reviewer = await GetByIdAsync(id);
        if (reviewer is null)
            return null;

        reviewer.FirstName = updateRequestReviewerDTO.FirstName;
        reviewer.LastName = updateRequestReviewerDTO.LastName;

        await _context.SaveChangesAsync();

        return reviewer;
    }
}
