using Microsoft.EntityFrameworkCore;
using MP5.Context;
using MP5.Models;

namespace MP5.Services.Players;

public class PlayerService : IPlayerService
{
    private readonly ApplicationDbContext _dbContext;

    public PlayerService(ApplicationDbContext applicationDbContext)
    {
        _dbContext = applicationDbContext;
    }
    
    public async Task<IEnumerable<Player>> GetAllPlayers()
    {
        return await _dbContext.Players.ToListAsync();
    }

    public Task AddPlayer(Player player)
    {
        throw new NotImplementedException();
    }
}