namespace MAS.Backend.Requests.Authentication;

public record RegisterRequest(
    string FirstName, 
    string LastName, 
    int Pesel,
    string Email,
    string Password,
    int PhoneNumber,
    DateTime DateOfBirth,
    string? BankAccount);