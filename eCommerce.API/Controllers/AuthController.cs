using eCommerce.Core.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity.Data;
using RegisterRequest = eCommerce.Core.DTO.RegisterRequest;
using eCommerce.Core.Interfaces;
using Microsoft.Identity.Client;
using LoginRequest = eCommerce.Core.DTO.LoginRequest;

namespace eCommerce.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IUsersService _usersService;
    private readonly ILogger<AuthController> _logger;

    public AuthController(IUsersService usersService, ILogger<AuthController> logger)
    {
        _usersService = usersService;
        _logger = logger;
    }
    
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest registerRequest)
    {
        if (registerRequest == null)
        {
            return BadRequest("Invalid registration Data");
        }
        
        AuthenticationResponse? result = await _usersService.Register(registerRequest);

        if (result == null || result.Success == false)
        {
            return BadRequest(result);
        }
        
        return Ok(result);
    }
    
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest loginRequest)
    {
        if (loginRequest == null)
        {
            return BadRequest("Invalid login Data");
        }
        
        AuthenticationResponse? result = await _usersService.Login(loginRequest);
        
        if (result == null)
        {
            return Unauthorized(loginRequest);
        }
        
        return Ok(result);
    }
}