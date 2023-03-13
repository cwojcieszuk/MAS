using MP5.Models;

namespace MP5.Services.Players;

public interface IPlayerService
{
    Task<IEnumerable<Player>> GetAllPlayers();
    Task AddPlayer(Player player);
}