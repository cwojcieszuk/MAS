using MAS.Backend.Entities;

namespace MAS.Backend.Persistence.Interfaces.Users;

public interface IUsersService
{
    Task<User?> GetUserByEmail(string email);
}