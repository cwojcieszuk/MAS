using System;
using System.Collections.Generic;

namespace MAS.Backend.Entities;

public partial class CouponOffer
{
    public int IdCouponOffer { get; set; }

    public int IdCoupon { get; set; }

    public int IdOffer { get; set; }

    public virtual Coupon IdCouponNavigation { get; set; } = null!;

    public virtual Offer IdOfferNavigation { get; set; } = null!;
}
