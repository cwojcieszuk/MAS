using System;
using System.Collections.Generic;

namespace MAS.Backend.Entities;

public partial class BetSport
{
    public int IdBetSport { get; set; }

    public string SportName { get; set; } = null!;

    public string Team1 { get; set; } = null!;

    public string Team2 { get; set; } = null!;

    public virtual ICollection<BetSportOption> BetSportOptions { get; set; } = new List<BetSportOption>();

    public virtual ICollection<Bet> Bets { get; set; } = new List<Bet>();
}
