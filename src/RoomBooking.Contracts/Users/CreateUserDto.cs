namespace RoomBooking.Contracts.Users;

public record CreateUserDto(string Name, string Email, string PasswordHash);