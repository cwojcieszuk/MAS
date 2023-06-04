namespace MAS.Backend.Responses.Users;

public record BasicInfoResponse(string Name, string Surname, string Login, string Email, int PhoneNumber, DateTime DateOfBirth);