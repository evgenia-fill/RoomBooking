namespace RoomBooking.Contracts.Bookings;

public record CreateBookingDto(
    string Title,
    string? Description,
    Guid UserId,
    int RoomId,
    DateTimeOffset StartTime,
    DateTimeOffset EndTime);