using System;
using System.Collections.Generic;

namespace MAS.Backend.Entities;

public partial class BetEsport
{
    public int IdBetEsport { get; set; }

    public string GameName { get; set; } = null!;

    public string Team1 { get; set; } = null!;

    public string Team2 { get; set; } = null!;

    public virtual ICollection<BetEsportOption> BetEsportOptions { get; set; } = new List<BetEsportOption>();

    public virtual ICollection<Bet> Bets { get; set; } = new List<Bet>();
}
