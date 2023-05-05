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
    public async Task<IActionResult> PlaceCoupon(PlaceCouponRequest request)
    {
        await _couponsService.PlaceCoupon(request);
        return NoContent();
    }
}