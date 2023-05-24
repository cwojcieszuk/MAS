using MAS.Backend.Requests.Coupons;
using MAS.Backend.Shared.Models;

namespace MAS.Backend.Persistence.Interfaces.Coupons;

public interface ICouponsService
{
    Task PlaceCoupon(PlaceCouponRequest request);
    Task<ValidationError> ValidatePlaceCoupon(PlaceCouponRequest request);
}