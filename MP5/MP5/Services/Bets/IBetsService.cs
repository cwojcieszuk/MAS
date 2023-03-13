using MP5.DTO;
using MP5.Models;

namespace MP5.Services.Bets;

public interface IBetsService
{
    Task<IEnumerable<GetAllBetsDTO>> GetAllSportBets();
    Task<IEnumerable<GetAllBetsDTO>> GetAllEventBets();
    Task AddBet(AddBetDTO dto);
}