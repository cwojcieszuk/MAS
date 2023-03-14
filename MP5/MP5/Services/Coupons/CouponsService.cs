using Microsoft.EntityFrameworkCore;
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

    public async Task<IEnumerable<GetCouponsByPlayerDTO>> GetCouponByPlayer(int idPlayer)
    {
        return await _dbContext.PlayerCoupons.Where(obj => obj.IdPlayer == idPlayer).Select(obj =>
            new GetCouponsByPlayerDTO()
            {
                PlayerId = idPlayer,
                CouponId = obj.IdCoupon,
                Amount = obj.Amount,
                Date = obj.Coupon.Date,
                FullRate = obj.Coupon.FullRate,
                PotentialWin = obj.Coupon.PotentialWin,
                Bets = obj.Coupon.BetCoupons.Select(betCoupon => new Bet()
                {
                    IdBet = betCoupon.IdBet, 
                    Category = betCoupon.Bet.Category, 
                    Rate = betCoupon.Bet.Rate,
                    BetType = betCoupon.Bet.BetType,
                    EventName = betCoupon.Bet.EventName,
                    SportName = betCoupon.Bet.SportName,
                })
            }).ToListAsync();
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