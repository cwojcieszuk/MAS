namespace MAS.Backend.Responses.Bets;

public record EsportBetsResponse(int IdBet, DateTime DateTime, int? IdSportBet, string Game, string Team1, string Team2, List<EsportBetOptions> Options);

public record EsportBetOptions(int IdBetEsportOption, double Odds, string Status, string BetName);