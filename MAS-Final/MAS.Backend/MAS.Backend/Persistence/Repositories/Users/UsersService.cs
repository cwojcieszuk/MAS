using MAS.Backend.Data;
using MAS.Backend.Entities;
using MAS.Backend.Persistence.Interfaces.Authentication;
using MAS.Backend.Persistence.Interfaces.Users;
using MAS.Backend.Requests.Users;
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

    public async Task<BasicInfoResponse> GetBasicInfo(int idUser)
    {
        var user = await _masContext.Users.FirstOrDefaultAsync(u => u.IdUser == idUser);

        BasicInfoResponse result = new BasicInfoResponse(user.FirstName, user.LastName, user.Login, user.Email, user.PhoneNumber, user.DateOfBirth);

        return result;
    }

    public async Task UpdateBasicInfo(int idUser, UpdateBasicInfoRequest request)
    {
        var user = await _masContext.Users.FirstOrDefaultAsync(u => u.IdUser == idUser);

        user.FirstName = request.Name;
        user.LastName = request.Surname;
        user.Email = request.Email;
        user.Login = request.Login;
        user.PhoneNumber = request.PhoneNumber;
        user.DateOfBirth = request.DateOfBirth;

        await _masContext.SaveChangesAsync();
    }

    public async Task<UserAddressResponse> GetAddress(int idUser)
    {
        var address = await _masContext.Addresses.FirstOrDefaultAsync(adres => adres.IdUser == idUser);

        var result = new UserAddressResponse(address.City, address.State, address.Street, address.PostalCode);

        return result;
    }

    public async Task UpdateAddress(int idUser, UpdateAddressRequest request)
    {
        var address = await _masContext.Addresses.FirstOrDefaultAsync(adres => adres.IdUser == idUser);

        if (address is null)
        {
            Address newAddress = new Address()
            {
                City = request.City,
                Street = request.Street,
                PostalCode = request.PostalCode,
                State = request.State,
                IdUser = request.IdUser,
            };

            _masContext.Addresses.Add(newAddress);
            await _masContext.SaveChangesAsync();
            
            return;
        }

        address.City = request.City;
        address.State = request.State;
        address.Street = request.Street;
        address.PostalCode = request.PostalCode;

        await _masContext.SaveChangesAsync();
    }
}