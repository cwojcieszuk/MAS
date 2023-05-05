using MAS.Backend.Requests.Coupons;

namespace MAS.Backend.Persistence.Interfaces.Coupons;

public interface ICouponsService
{
    Task PlaceCoupon(PlaceCouponRequest request);
}