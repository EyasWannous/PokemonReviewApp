using System.ComponentModel.DataAnnotations;

namespace PokemonReviewApp.DTO.Category;

public class CategoryDTO
{
    [Required]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; } = string.Empty;
}
