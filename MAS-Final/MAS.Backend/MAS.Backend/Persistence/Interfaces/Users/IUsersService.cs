using MAS.Backend.Entities;
using MAS.Backend.Responses.Users;

namespace MAS.Backend.Persistence.Interfaces.Users;

public interface IUsersService
{
    Task<User?> GetUserByEmail(string email);
    Task<UserAccountResponse> GetUserAccount(int idUser);
    Task AddMoney(int idUser, double amount);
}