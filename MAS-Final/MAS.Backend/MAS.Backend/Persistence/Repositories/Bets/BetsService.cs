using MAS.Backend.Data;
using MAS.Backend.Persistence.Interfaces.Bets;
using MAS.Backend.Responses.Bets;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MAS.Backend.Persistence.Repositories.Bets;

public class BetsService : IBetsService
{
    private readonly MasContext _masContext;

    public BetsService(MasContext masContext)
    {
        _masContext = masContext;
    }

    public async Task<IEnumerable<SportBetsResponse>> GetSportBets()
    {
        return await _masContext.Bets.Where(bet => bet.IdBetSport != null).Select(bet =>
            new SportBetsResponse(
                bet.IdBet,
                bet.Date,
                bet.IdBetSport,
                bet.IdBetSportNavigation.SportName,
                bet.IdBetSportNavigation.Team1,
                bet.IdBetSportNavigation.Team2,
                bet.IdBetSportNavigation.BetSportOptions.
                    Select(betOption => new SportBetOptions(
                        betOption.IdBetSportOption, 
                        betOption.Odds, 
                        betOption.IdBetStatusNavigation.Status,
                        betOption.IdBetSportTypeNavigation.Name
                        )).ToList()
            )).ToListAsync();
    }

    public async Task<IEnumerable<EsportBetsResponse>> GetEsportBets()
    {
        return await _masContext.Bets.Where(bet => bet.IdBetEsport != null).Select(bet =>
            new EsportBetsResponse(
                bet.IdBet,
                bet.Date,
                bet.IdBetEsport,
                bet.IdBetEsportNavigation.GameName,
                bet.IdBetEsportNavigation.Team1,
                bet.IdBetEsportNavigation.Team2,
                bet.IdBetEsportNavigation.BetEsportOptions.
                    Select(betOption => new EsportBetOptions(
                        betOption.IdBetEsportOption,
                        betOption.Odds,
                        betOption.IdBetStatusNavigation.Status,
                        betOption.IdBetEsportTypeNavigation.Name
                        )).ToList()
            )).ToListAsync();
    }
}