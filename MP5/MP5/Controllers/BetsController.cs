using Microsoft.AspNetCore.Mvc;
using MP5.DTO;
using MP5.Services.Bets;

namespace MP5.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BetsController : ControllerBase
{
    private readonly IBetsService _betsService;

    public BetsController(IBetsService betsService)
    {
        _betsService = betsService;
    }

    [HttpGet("sports")]
    public async Task<IActionResult> GetAllSportBets()
    {
        var bets = await _betsService.GetAllSportBets();
        return Ok(bets);
    }

    [HttpGet("events")]
    public async Task<IActionResult> GetAllEventBets()
    {
        var bets = await _betsService.GetAllEventBets();
        return Ok(bets);
    }

    [HttpPost]
    public async Task<IActionResult> AddBet(AddBetDTO dto)
    {
        await _betsService.AddBet(dto);
        return Ok("Added bet");
    }
}