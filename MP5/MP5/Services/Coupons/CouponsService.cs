using MP5.Context;
using MP5.DTO;
using MP5.Models;

namespace MP5.Services.Coupons;

public class CouponsService : ICouponsService
{
    private readonly ApplicationDbContext _dbContext;

    public CouponsService(ApplicationDbContext applicationDbContext)
    {
        _dbContext = applicationDbContext;
    }

    public async Task AddCoupon(AddCouponDTO dto)
    {
        var bets = _dbContext.Bets.Where(obj => dto.BetIds.Any(id => obj.IdBet == id));
        var fullRate = CountFullRateForCoupon(bets.Select(obj => obj.Rate).ToList());
        var coupon = new Coupon()
        {
            FullRate = fullRate,
            PotentialWin = CountPotentialWinForCoupon(fullRate, dto.Amount),
            Date = DateTime.Now,
        };

        _dbContext.Coupons.Add(coupon);
        await _dbContext.SaveChangesAsync();
        
        var playerCoupon = new PlayerCoupon()
        {
            IdCoupon = coupon.IdCoupon,
            IdPlayer = dto.IdPlayer,
            Amount = dto.Amount,
        };

        var betCoupons = new List<BetCoupon>();
        foreach (var betId in dto.BetIds)
        {
            betCoupons.Add(new BetCoupon(){ IdCoupon = coupon.IdCoupon, IdBet = betId });
        }
        
        _dbContext.BetCoupons.AddRange(betCoupons);
        _dbContext.PlayerCoupons.Add(playerCoupon);
        await _dbContext.SaveChangesAsync();
    }

    private int FindLatestCouponId()
    {
        return _dbContext.Coupons.Max(obj => (int?)obj.IdCoupon) ?? 0;
    }

    private double CountFullRateForCoupon(List<double> rates)
    {
        return rates.Sum();
    }

    private double CountPotentialWinForCoupon(double fullRate, double amount)
    {
        return fullRate * amount;
    }
}