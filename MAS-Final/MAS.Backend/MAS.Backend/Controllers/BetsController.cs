using MAS.Backend.Persistence.Interfaces.Bets;
using Microsoft.AspNetCore.Mvc;

namespace MAS.Backend.Controllers;

[Route("api/bets")]
[ApiController]
public class BetsController : ControllerBase
{
    private readonly IBetsService _betsService;

    public BetsController(IBetsService betsService)
    {
        _betsService = betsService;
    }

    [HttpGet]
    [Route("sport")]
    public async Task<IActionResult> GetSportBets()
    {
        return Ok(await _betsService.GetSportBets());
    }

    [HttpGet]
    [Route("esport")]
    public async Task<IActionResult> GetEsportBets()
    {
        return Ok(await _betsService.GetEsportBets());
    }
}