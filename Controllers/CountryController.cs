using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewApp.DTO.Country;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Mappers;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CountryController(ICountryRepository countryRepository) : ControllerBase
{
    private readonly ICountryRepository _countryRepository = countryRepository;


    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var countries = await _countryRepository.GetCountriesAsync();

        return Ok(countries.Select(country => country.ToCountryDTO()));
    }


    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var country = await _countryRepository.GetByIdAsync(id);
        if (country is null)
            return NotFound();

        return Ok(country.ToCountryDTO());
    }


    [HttpGet("{name}")]
    public async Task<IActionResult> GetByName([FromRoute] string name)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var country = await _countryRepository.GetByNameAsync(name);
        if (country is null)
            return NotFound();

        return Ok(country.ToCountryDTO());
    }


    [HttpGet("owner/{ownerId:int}")]
    public async Task<IActionResult> GetByOwnerId([FromRoute] int ownerId)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var country = await _countryRepository.GetByOwnerIdAsync(ownerId);
        if (country is null)
            return NotFound();

        return Ok(country.ToCountryDTO());
    }


    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateRequestCountryDTO createRequestCountryDTO)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var country = await _countryRepository.CreateAsync(createRequestCountryDTO);

        return CreatedAtAction(nameof(GetById), new { id = country.Id }, country.ToCountryDTO());
    }


    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var country = await _countryRepository.DeleteAsync(id);
        if (country is null)
            return NotFound();

        return NoContent();
    }


    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, UpdateRequestCountryDTO updateRequestCountryDTO)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var country = await _countryRepository.UpdateAsync(id, updateRequestCountryDTO);
        if (country is null)
            return NotFound();

        return Ok(country.ToCountryDTO());
    }
}
