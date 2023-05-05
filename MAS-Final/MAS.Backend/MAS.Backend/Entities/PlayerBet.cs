using System;
using System.Collections.Generic;

namespace MAS.Backend.Entities;

public partial class PlayerBet
{
    public int IdPlayerBet { get; set; }

    public float Amount { get; set; }

    public int IdUser { get; set; }

    public int IdCoupon { get; set; }

    public virtual Coupon IdCouponNavigation { get; set; } = null!;

    public virtual User IdUserNavigation { get; set; } = null!;
}
