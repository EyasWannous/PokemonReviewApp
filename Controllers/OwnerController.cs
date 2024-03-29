using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewApp.DTO.Owner;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Mappers;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OwnerController(IOwnerRepository ownerRepository) : ControllerBase
{
    private readonly IOwnerRepository _ownerRepository = ownerRepository;


    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        if(!ModelState.IsValid)
            return BadRequest(ModelState);

        var owners = await _ownerRepository.GetOwnersAsync();

        return Ok(owners.Select(owner => owner.ToOwnerDTO()));
    }


    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var owners = await _ownerRepository.GetByIdAsync(id);
        if (owners is null)
            return NotFound();

        return Ok(owners.ToOwnerDTO());
    }


    [HttpPost("{countryId:int}")]
    public async Task<IActionResult> Create([FromRoute] int countryId, [FromBody] CreateRequestOwnerDTO createRequestOwnerDTO)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var owner = await _ownerRepository.CreateAsync(countryId,createRequestOwnerDTO);
        if (owner is null)
            return NotFound("Country Not Found");

        return CreatedAtAction(nameof(GetById), new { id = owner.Id }, owner.ToOwnerDTO());
    }


    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var owner = await _ownerRepository.DeleteAsync(id);
        if (owner is null)
            return NotFound();

        return NoContent();
    }


    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateRequestOwnerDTO updateRequestOwnerDTO)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var owner = await _ownerRepository.UpdateAsync(id, updateRequestOwnerDTO);
        if (owner is null)
            return NotFound();

        return Ok(owner.ToOwnerDTO());
    }
}
