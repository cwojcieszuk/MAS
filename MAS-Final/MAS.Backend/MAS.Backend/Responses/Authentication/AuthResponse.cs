using MAS.Backend.Entities;

namespace MAS.Backend.Responses.Authentication;

public record AuthResponse(string RefreshToken, string AccessToken);