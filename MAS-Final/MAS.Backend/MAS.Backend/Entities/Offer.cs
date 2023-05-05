using System;
using System.Collections.Generic;

namespace MAS.Backend.Entities;

public partial class Offer
{
    public int IdOffer { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public float Bonus { get; set; }

    public virtual ICollection<CouponOffer> CouponOffers { get; set; } = new List<CouponOffer>();
}
