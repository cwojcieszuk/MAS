using System;
using System.Collections.Generic;

namespace MAS.Backend.Entities;

public partial class BetSportOption
{
    public int IdBetSportOption { get; set; }

    public int IdBetSportType { get; set; }

    public int IdBetSport { get; set; }

    public float Odds { get; set; }

    public int IdBetStatus { get; set; }

    public virtual ICollection<BetCoupon> BetCoupons { get; set; } = new List<BetCoupon>();

    public virtual BetSport IdBetSportNavigation { get; set; } = null!;

    public virtual BetSportType IdBetSportTypeNavigation { get; set; } = null!;

    public virtual BetStatus IdBetStatusNavigation { get; set; } = null!;
}
