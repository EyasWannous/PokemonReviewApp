using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;
using PokemonReviewApp.options;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PokemonReviewApp.Services;

public class TokenService(IOptions<JWTOptions> options) : ITokenService
{
    private readonly IOptions<JWTOptions> _options = options;

    public async Task<string> CreateTokenAsync(User user)
    {
        List<Claim> claims =
        [
            new(JwtRegisteredClaimNames.Email, user.Email!),
            new(JwtRegisteredClaimNames.GivenName, user.UserName!)
        ];

        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.Value.SigningKey));

        var signingCredentials = new SigningCredentials(symmetricSecurityKey,SecurityAlgorithms.HmacSha512Signature);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            SigningCredentials = signingCredentials,
            Expires = DateTime.Now.AddHours(_options.Value.Lifetime),
            Issuer = _options.Value.Issuer,
            Audience = _options.Value.Audience,
        };

        var tokenHandler = new JwtSecurityTokenHandler();

        var securityToken = tokenHandler.CreateToken(tokenDescriptor);

        var accessToken = tokenHandler.WriteToken(securityToken);
        return await Task.FromResult(accessToken);
    }

    public Task<string> GetTokenAsync(string token)
    {
        throw new NotImplementedException();
    }
}
