using MAS.Backend.Entities;

namespace MAS.Backend.Jwt;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}