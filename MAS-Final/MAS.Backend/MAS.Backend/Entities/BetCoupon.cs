using System;
using System.Collections.Generic;

namespace MAS.Backend.Entities;

public partial class BetCoupon
{
    public int IdBetCoupon { get; set; }

    public int IdCoupon { get; set; }

    public int? IdBetSportOption { get; set; }

    public int? IdBetEsportOption { get; set; }

    public virtual BetEsportOption? IdBetEsportOptionNavigation { get; set; }

    public virtual BetSportOption? IdBetSportOptionNavigation { get; set; }

    public virtual Coupon IdCouponNavigation { get; set; } = null!;
}
