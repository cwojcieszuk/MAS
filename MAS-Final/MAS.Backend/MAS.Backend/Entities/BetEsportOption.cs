using System;
using System.Collections.Generic;

namespace MAS.Backend.Entities;

public partial class BetEsportOption
{
    public int IdBetEsportOption { get; set; }

    public int IdBetEsportType { get; set; }

    public int IdBetEsport { get; set; }

    public float Odds { get; set; }

    public int IdBetStatus { get; set; }

    public virtual ICollection<BetCoupon> BetCoupons { get; set; } = new List<BetCoupon>();

    public virtual BetEsport IdBetEsportNavigation { get; set; } = null!;

    public virtual BetEsportType IdBetEsportTypeNavigation { get; set; } = null!;

    public virtual BetStatus IdBetStatusNavigation { get; set; } = null!;
}
