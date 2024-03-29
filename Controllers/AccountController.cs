using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewApp.DTO.Account;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;

namespace PokemonReviewApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController(ITokenService tokenService, 
    UserManager<User> userManager, SignInManager<User> signInManager) : ControllerBase
{
    private readonly ITokenService _tokenService = tokenService;
    private readonly UserManager<User> _userManager = userManager;
    private readonly SignInManager<User> _signInManager = signInManager;


    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDTO registerDTO)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var user = new User
        {
            UserName = registerDTO.UserName,
            Email = registerDTO.Email,
        };

        try
        {
            var createUser = await _userManager.CreateAsync(user, registerDTO.Password!);
            if (createUser is null)
                return BadRequest();

            if (!createUser.Succeeded)
                return StatusCode(500, createUser.Errors);

            var role = await _userManager.AddToRoleAsync(user, "User");
            if (role is null)
                return BadRequest();

            if (!role.Succeeded)
                return StatusCode(500, role.Errors);

            var newUser = new CreatedUserDTO
            {
                UserName = registerDTO.UserName,
                Email = registerDTO.Email,
                Token = await _tokenService.CreateTokenAsync(user),
            };

            return Ok(newUser);
        }
        catch (Exception error)
        {
            return StatusCode(500, error);
        }
    }


    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginUserDTO loginUserDTO)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var user = await _userManager.FindByEmailAsync(loginUserDTO.Email);
        if (user is null)
            return Unauthorized("Email not found");

        var result = await _signInManager.CheckPasswordSignInAsync(user, loginUserDTO.Password, false);

        if (!result.Succeeded)
            return Unauthorized("Email or Password incorrect");

        var newUserAfterLogin = new CreatedUserDTO
        {
            Email = loginUserDTO.Email,
            UserName = user.UserName!,
            Token = await _tokenService.CreateTokenAsync(user),
        };

        return Ok(newUserAfterLogin);
    }

}
