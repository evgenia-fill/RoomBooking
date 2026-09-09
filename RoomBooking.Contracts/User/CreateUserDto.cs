namespace RoomBooking.Contracts.User;

public record CreateUserDto(string Name, string Email, string PasswordHash);