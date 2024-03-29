using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace PokemonReviewApp.Extensions;

public static class ClaimsExtensions
{
    public static async Task<string?> GetUsername(this ClaimsPrincipal claimsPrincipal)
    {
        if (claimsPrincipal.Identity is not ClaimsIdentity principal)
            return await Task.FromResult<string?>(null);

        var username = principal.FindFirst(ClaimTypes.GivenName)?.Value;
        username ??= principal.FindFirst(JwtRegisteredClaimNames.GivenName)?.Value;

        return await Task.FromResult(username);
    }

    public static async Task<string?> GetEmail(this ClaimsPrincipal claimsPrincipal)
    {
        if (claimsPrincipal.Identity is not ClaimsIdentity principal)
            return await Task.FromResult<string?>(null);

        var Email = principal.FindFirst(ClaimTypes.Email)?.Value;
        Email ??= principal.FindFirst(JwtRegisteredClaimNames.Email)?.Value;

        return await Task.FromResult(Email);
    }
}
