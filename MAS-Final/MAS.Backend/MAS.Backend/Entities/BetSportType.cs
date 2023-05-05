using System;
using System.Collections.Generic;

namespace MAS.Backend.Entities;

public partial class BetSportType
{
    public int IdBetSportType { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<BetSportOption> BetSportOptions { get; set; } = new List<BetSportOption>();
}
