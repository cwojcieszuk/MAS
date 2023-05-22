using MAS.Backend.Persistence.Interfaces.Authentication;
using MAS.Backend.Persistence.Interfaces.Users;
using MAS.Backend.Requests.Authentication;
using MAS.Backend.Requests.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MAS.Backend.Controllers;

[Route("api/auth")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    private readonly IUsersService _usersService;
    private readonly IAuthenticationService _authenticationService;

    public AuthenticationController(IUsersService usersService, IAuthenticationService authenticationService)
    {
        _usersService = usersService;
        _authenticationService = authenticationService;
    }

    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        if (await _usersService.GetUserByEmail(request.Email) != null)
        {
            return BadRequest("User with this email already exists!");
        }

        if (request.Password.Length < 8)
        {
            return BadRequest("Password length must be at least 8");
        }

        var result = await _authenticationService.Register(request);

        return Ok(result);
    }

    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        if (await _usersService.GetUserByEmail(request.Email) == null)
        {
            return BadRequest("User doesnt exist!");
        }

        var result = await _authenticationService.Login(request);
        
        if (result is null)
        {
            return BadRequest("Email or password bad");
        }
        
        return Ok(result);
    }

    [HttpGet("{idUser}")]
    [Authorize]
    public async Task<IActionResult> GetUserAccount(int idUser)
    {
        var result = await _usersService.GetUserAccount(idUser);

        return Ok(result);
    }

    [HttpPost("money")]
    [Authorize]
    public async Task<IActionResult> AddMoney(AddMoneyRequest request)
    {
        await _usersService.AddMoney(request.IdUser, request.Amount);

        return NoContent();
    }
}