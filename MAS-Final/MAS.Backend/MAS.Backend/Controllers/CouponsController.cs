using MAS.Backend.Persistence.Interfaces.Coupons;
using MAS.Backend.Requests.Coupons;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MAS.Backend.Controllers;

[Route("api/coupons")]
[ApiController]
public class CouponsController : ControllerBase
{
    private readonly ICouponsService _couponsService;

    public CouponsController(ICouponsService couponsService)
    {
        _couponsService = couponsService;
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> PlaceCoupon(PlaceCouponRequest request)
    {
        var validationResult = await _couponsService.ValidatePlaceCoupon(request);

        if (validationResult == false)
        {
            return BadRequest();
        }
        
        await _couponsService.PlaceCoupon(request);
        return NoContent();
    }
}