using MAS.Backend.Requests.Authentication;
using MAS.Backend.Responses.Authentication;

namespace MAS.Backend.Persistence.Interfaces.Authentication;

public interface IAuthenticationService
{
    Task<AuthResponse> Register(RegisterRequest request);
    Task<AuthResponse> Login(LoginRequest request);
}