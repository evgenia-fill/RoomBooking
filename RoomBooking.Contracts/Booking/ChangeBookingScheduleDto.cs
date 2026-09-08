namespace RoomBooking.Contracts.Booking;

public record ChangeBookingScheduleDto(DateTimeOffset StartTime,  DateTimeOffset EndTime);