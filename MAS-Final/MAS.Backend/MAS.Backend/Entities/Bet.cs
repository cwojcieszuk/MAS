using System;
using System.Collections.Generic;

namespace MAS.Backend.Entities;

public partial class Bet
{
    public int IdBet { get; set; }

    public DateTime Date { get; set; }

    public int? IdBetSport { get; set; }

    public int? IdBetEsport { get; set; }

    public virtual BetEsport? IdBetEsportNavigation { get; set; }

    public virtual BetSport? IdBetSportNavigation { get; set; }
}
