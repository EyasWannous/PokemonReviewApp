using Microsoft.EntityFrameworkCore;
using PokemonReviewApp.Data;
using PokemonReviewApp.DTO.Category;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Mappers;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Repositories;

public class CategoryRepository(AppDbContext context) : ICategoryRepository
{
    private readonly AppDbContext _context = context;

    public async Task<Category> CreateAsync(CreateRequestCategoryDTO createRequestCategoryDTO)
    {
        var category = createRequestCategoryDTO.FromCreateToCategroy();

        await _context.Categories.AddAsync(category);

        await _context.SaveChangesAsync();

        return category;
    }

    public async Task<Category?> DeleteAsync(int id)
    {
        var category = await GetByIdAsync(id);
        if (category is null)
            return null;

        _context.Categories.Remove(category);

        await _context.SaveChangesAsync();

        return category;
    }

    public async Task<Category?> GetByIdAsync(int id)
        => await _context.Categories.FirstOrDefaultAsync(category => category.Id == id);

    public async Task<ICollection<Category>> GetCategoriesAsync()
        => await _context.Categories.ToListAsync();

    public async Task<bool> IsExistsAsync(int id)
        => await _context.Categories.AnyAsync(category => category.Id == id);

    public async Task<Category?> UpdateAsync(int id, UpdateRequestCategoryDTO updateRequestCategoryDTO)
    {
        var category = await GetByIdAsync(id);
        if (category is null) 
            return null;

        category.Name = updateRequestCategoryDTO.Name;

        await _context.SaveChangesAsync();

        return category;
    }
}
