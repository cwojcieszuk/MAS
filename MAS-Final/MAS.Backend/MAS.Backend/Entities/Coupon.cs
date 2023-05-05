using System;
using System.Collections.Generic;

namespace MAS.Backend.Entities;

public partial class Coupon
{
    public int IdCoupon { get; set; }

    public DateTime Date { get; set; }

    public double TotalRate { get; set; }

    public double PotentialWin { get; set; }

    public virtual ICollection<BetCoupon> BetCoupons { get; set; } = new List<BetCoupon>();

    public virtual ICollection<CouponOffer> CouponOffers { get; set; } = new List<CouponOffer>();

    public virtual ICollection<PlayerBet> PlayerBets { get; set; } = new List<PlayerBet>();
}
