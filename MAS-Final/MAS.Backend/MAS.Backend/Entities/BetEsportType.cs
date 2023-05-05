using System;
using System.Collections.Generic;

namespace MAS.Backend.Entities;

public partial class BetEsportType
{
    public int IdBetEsportType { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<BetEsportOption> BetEsportOptions { get; set; } = new List<BetEsportOption>();
}
