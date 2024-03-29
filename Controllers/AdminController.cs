using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PokemonReviewApp.DTO.Admin;
using PokemonReviewApp.Extensions;
using PokemonReviewApp.Models;
using System.ComponentModel.DataAnnotations;

namespace PokemonReviewApp.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class AdminController(UserManager<User> userManager) : ControllerBase
{
    private readonly UserManager<User> _userManager = userManager;


    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _userManager.Users.ToListAsync());


    [HttpGet("{email}")]
    public async Task<IActionResult> GetByEmail([FromRoute][EmailAddress] string email)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var user = await _userManager.FindByEmailAsync(email);
        if (user is null)
            return NotFound();

        return Ok(user);
    }


    [HttpGet("myinformation")]
    public async Task<IActionResult> GetMyInfromation()
    {
        var userEmail = await User.GetEmail();
        if (userEmail is null)
            return Unauthorized();

        var user = await _userManager.FindByEmailAsync(userEmail);
        if (user is null)
            return NotFound();

        var roles = await _userManager.GetRolesAsync(user);

        var userWithRolesToShow = new UserWithRoleToShowDTO
        {
            UserToShow = user,
            Roles = roles,
        };

        return Ok(userWithRolesToShow);
    }

}
