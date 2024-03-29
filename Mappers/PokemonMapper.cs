using PokemonReviewApp.DTO.Pokemon;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Mappers;

public static class PokemonMapper
{
    public static PokemonDTO ToPokemonDTO(this Pokemon pokemon)
    {
        return new PokemonDTO
        {
            Id = pokemon.Id,
            Name = pokemon.Name,
            BirthDate = pokemon.BirthDate,
        };
    }

    public static Pokemon FromCreateToPokemon(this CreateRequestPokemonDTO createRequestPokemonDTO)
    {
        return new Pokemon
        {
            Name = createRequestPokemonDTO.Name,
            BirthDate = createRequestPokemonDTO.BirthDate,
        };
    }

    public static Pokemon FromUpdateToPokemon(this UpdateRequestPokemonDTO updateRequsetPokemonDTO)
    {
        return new Pokemon
        {
            Name = updateRequsetPokemonDTO.Name,
        };
    }

}
