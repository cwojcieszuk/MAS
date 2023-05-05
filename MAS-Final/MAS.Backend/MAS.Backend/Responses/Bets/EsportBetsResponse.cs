namespace MAS.Backend.Responses.Bets;

public record EsportBetsResponse(int IdBet, DateTime DateTime, double Rate, string Name, int IdSportBet, string Game, string Team1, string Team2);