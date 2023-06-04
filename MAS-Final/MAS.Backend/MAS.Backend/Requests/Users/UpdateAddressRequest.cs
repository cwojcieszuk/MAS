namespace MAS.Backend.Requests.Users;

public record UpdateAddressRequest(int IdUser, string City, string State, string Street, string PostalCode);