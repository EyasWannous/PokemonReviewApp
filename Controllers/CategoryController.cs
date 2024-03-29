using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using PokemonReviewApp.DTO.Category;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Mappers;

namespace PokemonReviewApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController(ICategoryRepository categoryRepository) : ControllerBase
{
    private readonly ICategoryRepository _categoryRepository = categoryRepository;


    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var categroies = await _categoryRepository.GetCategoriesAsync();

        return Ok(categroies.Select(category => category.ToCategoryDTO()));
    }


    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var category = await _categoryRepository.GetByIdAsync(id);

        if (category is null)
            return NotFound();

        return Ok(category.ToCategoryDTO());
    }


    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateRequestCategoryDTO createRequestCategoryDTO)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var categroy = await _categoryRepository.CreateAsync(createRequestCategoryDTO);

        return CreatedAtAction(nameof(GetById), new { id = categroy.Id }, categroy.ToCategoryDTO());
    }


    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var categroy = await _categoryRepository.DeleteAsync(id);
        if (categroy is null)
            return NotFound();
    
        return NoContent();
    }


    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateRequestCategoryDTO updateRequestCategoryDTO)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var categroy = await _categoryRepository.UpdateAsync(id, updateRequestCategoryDTO);
        if (categroy is null)
            return NotFound();

        return Ok(categroy.ToCategoryDTO());
    }
}
