using Microsoft.AspNetCore.Mvc;
using MP5.DTO;
using MP5.Services.Coupons;

namespace MP5.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CouponsController : Controller
{
    private readonly ICouponsService _couponsService;

    public CouponsController(ICouponsService couponsService)
    {
        _couponsService = couponsService;
    }

    [HttpPost]
    public async Task<IActionResult> AddCoupon(AddCouponDTO dto)
    {
        await _couponsService.AddCoupon(dto);
        return NoContent();
    }
    //get coupons for player
    //create coupon id player id coupon
}