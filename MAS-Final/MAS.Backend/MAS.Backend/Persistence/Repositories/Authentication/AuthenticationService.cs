using System.Security.Cryptography;
using MAS.Backend.Data;
using MAS.Backend.Entities;
using MAS.Backend.Jwt;
using MAS.Backend.Persistence.Interfaces.Authentication;
using MAS.Backend.Persistence.Interfaces.Users;
using MAS.Backend.Requests.Authentication;
using MAS.Backend.Responses.Authentication;
using Microsoft.AspNetCore.Identity;

namespace MAS.Backend.Persistence.Repositories.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly MasContext _masContext;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly PasswordHasher<User> _passwordHasher;
    private readonly IUsersService _usersService;

    public AuthenticationService(MasContext masContext, IJwtTokenGenerator jwtTokenGenerator, IUsersService usersService)
    {
        _masContext = masContext;
        _jwtTokenGenerator = jwtTokenGenerator;
        _passwordHasher = new PasswordHasher<User>();
        _usersService = usersService;
    }
    
    public async Task<AuthResponse> Register(RegisterRequest request)
    {
        User user = new User
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            PhoneNumber = request.PhoneNumber,
            DateOfBirth = request.DateOfBirth,
            Pesel = request.Pesel
        };
        
        user.Age = DateTime.Now.Year - request.DateOfBirth.Year;

        user.Password = _passwordHasher.HashPassword(user, request.Password);
        user.RefreshToken = GenerateRefreshToken();
        user.RefreshTokenExpiration = DateTime.UtcNow.AddSeconds(86400);

        _masContext.Users.Add(user);
        await _masContext.SaveChangesAsync();
        
        Account account = new Account { IdAccount = user.IdUser, Money = 0 };
        
        if (request.BankAccount != null)
        {
            account.BankAccount = request.BankAccount;
        }

        _masContext.Accounts.Add(account);
        await _masContext.SaveChangesAsync();
        
        var token = _jwtTokenGenerator.GenerateToken(user);
        AuthResponse response = new AuthResponse(user.RefreshToken, token);

        return response;
    }

    public async Task<AuthResponse> Login(LoginRequest request)
    {
        User? user = await _usersService.GetUserByEmail(request.Email);

        if (_passwordHasher.VerifyHashedPassword(user, user.Password, request.Password) ==
            PasswordVerificationResult.Failed)
        {
            return null;
        }

        user.RefreshToken = GenerateRefreshToken();
        user.RefreshTokenExpiration = DateTime.UtcNow.AddSeconds(86400);

        await _masContext.SaveChangesAsync();
        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthResponse(user.RefreshToken, token);
    }

    private string GenerateRefreshToken()
    {
        var randomNumber = new byte[32];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomNumber);
        return Convert.ToBase64String(randomNumber);
    }
}