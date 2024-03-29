using PokemonReviewApp.DTO.Reviewer;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Interfaces;

public interface IReviewerRepository
{
    Task<ICollection<Reviewer>> GetReviewersAsync();
    Task<Reviewer?> GetByIdAsync(int id);
    Task<Reviewer?> GetByFullNameAsync(string name);
    Task<bool> IsExistsAsync(int id);
    Task<Reviewer> CreateAsync(CreateRequestReviewerDTO createRequestReviewerDTO);
    Task<Reviewer?> UpdateAsync(int id, UpdateRequestReviewerDTO updateRequestReviewerDTO);
    Task<Reviewer?> DeleteAsync(int id);
}
