using System;
using System.Collections.Generic;

namespace MAS.Backend.Entities;

public partial class BetStatus
{
    public int IdBetStatus { get; set; }

    public string Status { get; set; } = null!;

    public virtual ICollection<BetEsportOption> BetEsportOptions { get; set; } = new List<BetEsportOption>();

    public virtual ICollection<BetSportOption> BetSportOptions { get; set; } = new List<BetSportOption>();
}
