using MAS.Backend.Responses.Bets;

namespace MAS.Backend.Persistence.Interfaces.Bets;

public interface IBetsService
{
    Task<IEnumerable<SportBetsResponse>> GetSportBets();
    Task<IEnumerable<EsportBetsResponse>> GetEsportBets();
}