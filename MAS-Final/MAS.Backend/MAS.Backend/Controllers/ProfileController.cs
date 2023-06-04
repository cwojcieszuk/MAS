using MAS.Backend.Persistence.Interfaces.Users;
using MAS.Backend.Requests.Users;
using Microsoft.AspNetCore.Mvc;

namespace MAS.Backend.Controllers;

[Route("api/profile")]
[ApiController]
public class ProfileController : ControllerBase
{
    private readonly IUsersService _usersService;
    
    public ProfileController(IUsersService usersService)
    {
        _usersService = usersService;
    }

    [HttpGet("basic-info/{idUser}")]
    public async Task<IActionResult> GetBasicInfo(int idUser)
    {
        return Ok(await _usersService.GetBasicInfo(idUser));
    }

    [HttpPut("basic-info/{idUser}")]
    public async Task<IActionResult> UpdateBasicInfo(int idUser, [FromBody]UpdateBasicInfoRequest request)
    {
        await _usersService.UpdateBasicInfo(idUser, request);
        return Ok();
    }

    [HttpGet("address/{idUser}")]
    public async Task<IActionResult> GetAddress(int idUser)
    {
        return Ok(await _usersService.GetAddress(idUser));
    }

    [HttpPut("address/{idUser}")]
    public async Task<IActionResult> UpdateAddress(int idUser, UpdateAddressRequest request)
    {
        await _usersService.UpdateAddress(idUser, request);

        return Ok();
    }
}