namespace RoomBooking.Contracts.Bookings;

public record ChangeBookingScheduleDto(DateTimeOffset StartTime,  DateTimeOffset EndTime);