using MP5.DTO;

namespace MP5.Services.Coupons;

public interface ICouponsService
{
    Task AddCoupon(AddCouponDTO dto);
    Task<IEnumerable<GetCouponsByPlayerDTO>> GetCouponByPlayer(int idPlayer);
}