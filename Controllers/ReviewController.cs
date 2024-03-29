using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewApp.DTO.Review;
using PokemonReviewApp.DTO.Reviewer;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Mappers;
using PokemonReviewApp.Models;
using PokemonReviewApp.Repositories;

namespace PokemonReviewApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReviewController(IReviewRepository reviewRepository) : ControllerBase
{
    private readonly IReviewRepository _reviewRepository = reviewRepository;


    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var reviews = await _reviewRepository.GetReviewsAsync();

        return Ok(reviews.Select(review => review.ToReviewDTO()));
    }


    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var review = await _reviewRepository.GetByIdAsync(id);
        if (review is null)
            return NotFound();

        return Ok(review.ToReviewDTO());
    }


    [HttpPost("{reviewerId:int}/{pokemonId:int}")]
    public async Task<IActionResult> Create([FromRoute] int pokemonId, [FromRoute] int reviewerId, [FromBody] CreateRequestReviewDTO createRequestReviewDTO)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var review = await _reviewRepository.CreateAsync(pokemonId, reviewerId, createRequestReviewDTO);
        if (review is null)
            return NotFound("Reviewer Not Found Or Pokemon Not Found");

        return CreatedAtAction(nameof(GetById), new { id = review.Id }, review.ToReviewDTO());
    }


    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var review = await _reviewRepository.DeleteAsync(id);
        if (review is null)
            return NotFound();

        return NoContent();
    }


    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id,[FromBody] UpdateRequestReviewDTO updateRequestReviewDTO)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var reveiw = await _reviewRepository.UpdateAsync(id, updateRequestReviewDTO);
        if (reveiw is null)
            return NotFound();

        return Ok(reveiw.ToReviewDTO());
    }
}
