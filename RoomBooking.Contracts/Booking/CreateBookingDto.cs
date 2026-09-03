namespace RoomBooking.Contracts.Booking;

public record CreateBookingDto(
    string Title,
    string? Description,
    Guid UserId,
    int RoomId,
    DateTimeOffset StartTime,
    DateTimeOffset EndTime);