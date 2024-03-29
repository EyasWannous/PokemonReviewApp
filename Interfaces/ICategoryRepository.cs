using PokemonReviewApp.DTO.Category;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Interfaces;

public interface ICategoryRepository
{
    Task<ICollection<Category>> GetCategoriesAsync();
    Task<Category?> GetByIdAsync(int id);
    Task<bool> IsExistsAsync(int id);
    //Task<Category> GetByName(string name);
    Task<Category> CreateAsync(CreateRequestCategoryDTO createRequestCategoryDTO);
    Task<Category?> UpdateAsync(int id, UpdateRequestCategoryDTO updateRequestCategoryDTO);
    Task<Category?> DeleteAsync(int id);
}
