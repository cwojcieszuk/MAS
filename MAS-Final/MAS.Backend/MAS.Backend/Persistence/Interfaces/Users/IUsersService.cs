using MAS.Backend.Entities;
using MAS.Backend.Requests.Users;
using MAS.Backend.Responses.Users;

namespace MAS.Backend.Persistence.Interfaces.Users;

public interface IUsersService
{
    Task<User?> GetUserByEmail(string email);
    Task<UserAccountResponse> GetUserAccount(int idUser);
    Task AddMoney(int idUser, double amount);
    Task<BasicInfoResponse> GetBasicInfo(int idUser);
    Task UpdateBasicInfo(int idUser, UpdateBasicInfoRequest request);
    Task<UserAddressResponse> GetAddress(int idUser);
    Task UpdateAddress(int idUser, UpdateAddressRequest request);
}