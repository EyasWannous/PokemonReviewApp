using PokemonReviewApp.DTO.Owner;
using PokemonReviewApp.DTO.Pokemon;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Mappers;

public static class OwnerMapper
{
    public static OwnerDTO ToOwnerDTO(this Owner owner)
    {
        return new OwnerDTO
        {
            Id = owner.Id,
            Name = owner.Name,
            GYM = owner.GYM,
        };
    }

    public static Owner FromCreateToOwner(this CreateRequestOwnerDTO createRequestOwnerDTO)
    {
        return new Owner
        {
            Name = createRequestOwnerDTO.Name,
            GYM = createRequestOwnerDTO.GYM,
        };
    }

    public static Owner FromUpdateToOwner(this UpdateRequestOwnerDTO updateRequestOwnerDTO)
    {
        return new Owner
        {
            Name = updateRequestOwnerDTO.Name,
            GYM = updateRequestOwnerDTO.GYM,
        };
    }
}
