using MAS.Backend.Data;
using MAS.Backend.Entities;
using MAS.Backend.Persistence.Interfaces.Coupons;
using MAS.Backend.Requests.Coupons;
using Microsoft.EntityFrameworkCore;

namespace MAS.Backend.Persistence.Repositories.Coupons;

public class CouponsService : ICouponsService
{
    private readonly MasContext _masContext;

    public CouponsService(MasContext masContext)
    {
        _masContext = masContext;
    }

    public async Task PlaceCoupon(PlaceCouponRequest request)
    {
        var betSportOptions = _masContext.BetSportOptions.Where(obj => request.BetSportOptionIds.Any(id => obj.IdBetSportOption == id));
        var betEsportOptions = _masContext.BetEsportOptions.Where(obj => request.BetEsportOptionIds.Any(id => obj.IdBetEsportOption == id));
        var sportsFullRate = CountFullRateForCoupon(betSportOptions.Select(obj => obj.Odds).ToList());
        var esportsFullRate = CountFullRateForCoupon(betEsportOptions.Select(obj => obj.Odds).ToList());
        
        Coupon coupon = new Coupon
        {
            Date = DateTime.Now,
            TotalRate = sportsFullRate + esportsFullRate,
            PotentialWin = CountPotentialWinForCoupon(sportsFullRate + esportsFullRate, request.Amount)
        };

        _masContext.Coupons.Add(coupon);
        await _masContext.SaveChangesAsync();

        var playerBet = new PlayerBet()
        {
            IdCoupon = coupon.IdCoupon,
            IdUser = request.IdUser,
            Amount = request.Amount,
        };

        var betCoupons = new List<BetCoupon>();

        foreach (var betOptionId in request.BetSportOptionIds)
        {
            betCoupons.Add(new BetCoupon() { IdCoupon = coupon.IdCoupon, IdBetSportOption = betOptionId});
        }

        foreach (var betOptionId in request.BetEsportOptionIds)
        {
            betCoupons.Add(new BetCoupon() { IdCoupon = coupon.IdCoupon, IdBetEsportOption = betOptionId});
        }
        
        _masContext.BetCoupons.AddRange(betCoupons);
        _masContext.PlayerBets.Add(playerBet);
        await _masContext.SaveChangesAsync();

        var account = await _masContext.Accounts.FirstOrDefaultAsync(account => account.IdAccount == request.IdUser);

        account.Money -= request.Amount;

        await _masContext.SaveChangesAsync();
    }

    public async Task<bool> ValidatePlaceCoupon(PlaceCouponRequest request)
    {
        var user = await _masContext.Users.FirstOrDefaultAsync(user => user.IdUser == request.IdUser);

        if (user == null)
        {
            return false;
        }
        
        var account = await _masContext.Accounts.FirstOrDefaultAsync(acc => acc.IdAccount == user.IdUser);

        if (account.Money < request.Amount)
        {
            return false;
        }

        if (request.Amount < 2)
        {
            return false;
        }

        if (request.BetEsportOptionIds.Length == 0 || request.BetSportOptionIds.Length == 0)
        {
            return false;
        }

        return true;
    }

    private float CountFullRateForCoupon(List<float> rates)
    {
        return rates.Sum();
    }

    private float CountPotentialWinForCoupon(float fullRate, float amount)
    {
        return fullRate * amount;
    }
}