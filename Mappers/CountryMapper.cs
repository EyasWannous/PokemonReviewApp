using PokemonReviewApp.DTO.Country;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Mappers;

public static class CountryMapper
{
    public static CountryDTO ToCountryDTO(this Country country)
    {
        return new CountryDTO
        {
            Id = country.Id,
            Name = country.Name,
        };
    }

    public static Country FromCreateToCountry(this CreateRequestCountryDTO createRequestCountryDTO)
    {
        return new Country
        {
            Name = createRequestCountryDTO.Name,
        };
    }

    public static Country FromUpdateToCountry(this UpdateRequestCountryDTO updateRequestCountryDTO)
    {
        return new Country
        {
            Name = updateRequestCountryDTO.Name,
        };
    }
}
