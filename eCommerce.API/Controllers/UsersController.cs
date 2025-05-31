using eCommerce.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUsersService _usersService;
    
    public UsersController(IUsersService usersService)
    {
        _usersService = usersService;
    }

    [HttpGet("{userId}")]
    public async Task<IActionResult> GetUserById(Guid userId)
    {
        if (userId == Guid.Empty)
        {
            return BadRequest("Invalid User Id");
        }
        
        var user = _usersService.GetUserByUserId(userId);

        if (user == null)
        {
            return NotFound(user);
        }
        
        return Ok(user);
    }
}