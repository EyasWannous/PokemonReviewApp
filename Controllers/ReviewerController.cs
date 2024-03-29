using Microsoft.AspNetCore.Mvc;
using PokemonReviewApp.DTO.Review;
using PokemonReviewApp.DTO.Reviewer;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Mappers;

namespace PokemonReviewApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReviewerController(IReviewerRepository reviewerRepository) : ControllerBase
{
    private readonly IReviewerRepository _reviewerRepository = reviewerRepository;


    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var reveiwers = await _reviewerRepository.GetReviewersAsync();

        return Ok(reveiwers.Select(reviewer => reviewer.ToReviewerDTO()));
    }


    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var reveiwer = await _reviewerRepository.GetByIdAsync(id);
        if (reveiwer is null)
            return NotFound();

        return Ok(reveiwer.ToReviewerDTO());
    }


    [HttpGet("{name}")]
    public async Task<IActionResult> GetByFullName([FromRoute] string name)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var reveiwer = await _reviewerRepository.GetByFullNameAsync(name);
        if (reveiwer is null)
            return NotFound();

        return Ok(reveiwer.ToReviewerDTO());
    }


    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateRequestReviewerDTO createRequestReviewerDTO)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var reveiwer = await _reviewerRepository.CreateAsync(createRequestReviewerDTO);

        return CreatedAtAction(nameof(GetById), new { id = reveiwer.Id }, reveiwer.ToReviewerDTO());
    }


    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var reveiwer = await _reviewerRepository.DeleteAsync(id);
        if (reveiwer is null)
            return NotFound();

        return NoContent();
    }


    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateRequestReviewerDTO updateRequestReviewerDTO)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var reveiwer = await _reviewerRepository.UpdateAsync(id, updateRequestReviewerDTO);
        if (reveiwer is null)
            return NotFound();

        return Ok(reveiwer.ToReviewerDTO());
    }
}
