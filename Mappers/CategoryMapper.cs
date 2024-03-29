using PokemonReviewApp.DTO.Category;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Mappers;

public static class CategoryMapper
{
    public static CategoryDTO ToCategoryDTO(this Category category)
    {
        return new CategoryDTO
        {
            Id = category.Id,
            Name = category.Name,
        };
    }

    public static Category FromCreateToCategroy(this CreateRequestCategoryDTO createRequestCategoryDTO)
    {
        return new Category
        {
            Name = createRequestCategoryDTO.Name,
        };
    }

    public static Category FromUpdateToCategroy(this UpdateRequestCategoryDTO updateRequestCategoryDTO)
    {
        return new Category
        {
            Name = updateRequestCategoryDTO.Name,
        };
    }
}
