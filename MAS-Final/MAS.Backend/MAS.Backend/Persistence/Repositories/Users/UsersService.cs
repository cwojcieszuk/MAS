using MAS.Backend.Data;
using MAS.Backend.Entities;
using MAS.Backend.Persistence.Interfaces.Authentication;
using MAS.Backend.Persistence.Interfaces.Users;
using MAS.Backend.Responses.Users;
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

    public async Task<UserAccountResponse> GetUserAccount(int idUser)
    {
        var account = await _masContext.Accounts.FirstOrDefaultAsync(acc => acc.IdAccount == idUser);
        return new UserAccountResponse(account.Money, account.BankAccount);
    }

    public async Task AddMoney(int idUser, double amount)
    {
        var account = await _masContext.Accounts.FirstOrDefaultAsync(acc => acc.IdAccount == idUser);

        if (account == null)
        {
            return;
        }
        
        account.Money += amount;

        await _masContext.SaveChangesAsync();
    }
}