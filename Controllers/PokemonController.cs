using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewApp.DTO.Pokemon;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Mappers;
using PokemonReviewApp.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PokemonReviewApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PokemonController(IPokemonRepository pokemonRepository) : ControllerBase
{
    private readonly IPokemonRepository _pokemonRepository = pokemonRepository;


    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var pokemons = await _pokemonRepository.GetPokemonsAsync();

        return Ok(pokemons.Select(pokemon => pokemon.ToPokemonDTO()));
    }


    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var pokemon = await _pokemonRepository.GetByIdAsync(id);

        if (pokemon is null)
            return NotFound();

        return Ok(pokemon.ToPokemonDTO());
    }


    [HttpGet("{name}")]
    public async Task<IActionResult> GetByName([FromRoute] string name)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var pokemon = await _pokemonRepository.GetByNameAsync(name);

        if (pokemon is null)
            return NotFound();

        return Ok(pokemon.ToPokemonDTO());
    }


    [HttpGet("{id:int}/rating")]
    public async Task<IActionResult> GetPokemonRating([FromRoute] int id)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var pokemonRating = await _pokemonRepository.GetPokemonRatingAsync(id);

        if (pokemonRating is 0)
            return NotFound();

        return Ok(pokemonRating);
    }


    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var pokemon = await _pokemonRepository.DeleteAsync(id);

        if (pokemon is null)
            return NotFound();

        return Ok(pokemon);
    }


    [HttpGet("pokemon/{categoryId:int}")]
    public async Task<IActionResult> GetPokemonsByCategrotyId([FromRoute] int categoryId)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var pokemons = await _pokemonRepository.GetPokemonsByCategoryIdAsync(categoryId);
        if (pokemons.Count == 0)
            return NotFound();

        return Ok(pokemons.Select(pokemon => pokemon.ToPokemonDTO()));
    }


    [HttpGet("owner/{ownerId:int}")]
    public async Task<IActionResult> GetPokemonByOwnerId([FromRoute] int ownerId)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var pokemons = await _pokemonRepository.GetPokemonsByOwnerIdAsync(ownerId);
        if (pokemons.Count == 0)
            return NotFound();

        return Ok(pokemons.Select(pokemon => pokemon.ToPokemonDTO()));
    }


    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateRequestPokemonDTO pokemonToCreate)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var NewPokemon = await _pokemonRepository.CreateAsync(pokemonToCreate);

        return CreatedAtAction(nameof(GetById), new { id = NewPokemon.Id }, NewPokemon.ToPokemonDTO());
    }


    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateRequestPokemonDTO updateRequestPokemonDTO)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var pokemon = await _pokemonRepository.UpdateAsync(id, updateRequestPokemonDTO);
        if (pokemon is null)
            return NotFound();

        return Ok(pokemon.ToPokemonDTO());
    }
    
}
