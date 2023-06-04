namespace MAS.Backend.Requests.Users;

public record UpdateBasicInfoRequest(int idUser, string Name, string Surname, string Login, string Email, int PhoneNumber, DateTime DateOfBirth);