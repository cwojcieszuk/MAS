namespace MAS.Backend.Responses.Bets;

public record SportBetsResponse(int IdBet, DateTime DateTime, int? IdBetSport, string Sportname, string Team1, string Team2, List<SportBetOptions> Options);

public record SportBetOptions(int IdBetSportOption, double Odds, string Status, string BetName);