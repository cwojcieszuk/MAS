using MAS.Backend.Data;
using MAS.Backend.Entities;
using MAS.Backend.Persistence.Interfaces.Authentication;
using MAS.Backend.Persistence.Interfaces.Users;
using Microsoft.EntityFrameworkCore;

namespace MAS.Backend.Persistence.Repositories.Users;

public class UsersService : IUsersService
{
    private readonly MasContext _masContext;

    public UsersService(MasContext masContext)
    {
        _masContext = masContext;
    }
    
    public async Task<User?> GetUserByEmail(string email)
    {
        return await _masContext.Users.FirstOrDefaultAsync(user => user.Email == email);
    }
}