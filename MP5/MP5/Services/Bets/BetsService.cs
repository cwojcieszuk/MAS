using Microsoft.EntityFrameworkCore;
using MP5.Constants;
using MP5.Context;
using MP5.DTO;
using MP5.Models;

namespace MP5.Services.Bets;

public class BetsService : IBetsService
{
    private readonly ApplicationDbContext _dbContext;

    public BetsService(ApplicationDbContext applicationDbContext)
    {
        _dbContext = applicationDbContext;
    }

    public async Task<IEnumerable<Bet>> GetAllBets()
    {
        return await _dbContext.Bets.Select(obj => new Bet(){ IdBet = obj.IdBet }).ToListAsync();
    }

    public async Task<IEnumerable<GetAllBetsDTO>> GetAllSportBets()
    {
        return await _dbContext.Bets.Where(obj => obj.BetType == BetTypeConstants.SportsBet).Select(obj =>
            new GetAllBetsDTO()
            {
                IdBet = obj.IdBet,
                Category = obj.Category,
                Rate = obj.Rate,
                Name = obj.SportName,
                BetType = obj.BetType
            }).ToListAsync();
    }

    public async Task<IEnumerable<GetAllBetsDTO>> GetAllEventBets()
    {
        return await _dbContext.Bets.Where(obj => obj.BetType == BetTypeConstants.EventsBet).Select(obj =>
            new GetAllBetsDTO()
            {
                IdBet = obj.IdBet,
                Category = obj.Category,
                Rate = obj.Rate,
                Name = obj.EventName,
                BetType = obj.BetType
            }).ToListAsync();
    }

    public async Task AddBet(AddBetDTO dto)
    {
        var bet = new Bet()
        {
            Category = dto.Category,
            Rate = dto.Rate,
            BetType = dto.BetType,
        };
        
        if (dto.BetType == BetTypeConstants.EventsBet)
        {
            bet.EventName = dto.EventName;
        }

        if (dto.BetType == BetTypeConstants.SportsBet)
        {
            bet.SportName = dto.SportName;
        }

        
        _dbContext.Bets.Add(bet);
        await _dbContext.SaveChangesAsync();
    }
}