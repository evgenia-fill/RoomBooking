using RoomBooking.Contracts.Bookings;
using RoomBooking.Domain.Bookings;

namespace RoomBooking.Application.Bookings;

public interface IBookingService
{
    Task<Booking> CreateAsync(CreateBookingDto dto, CancellationToken cancellationToken);

    Task CancelBookingAsync(Guid bookingId, CancellationToken cancellationToken);

    Task<Booking?> GetByIdAsync(Guid bookingId, CancellationToken cancellationToken);

    Task<List<Booking>> GetAllAsync(CancellationToken cancellationToken);

    Task<List<Booking>> GetByRoomIdAsync(int roomId,
        CancellationToken cancellationToken);

    Task<List<Booking>> GetByUserIdAsync(Guid userId,
        CancellationToken cancellationToken);

    Task ChangeBookingTitleAsync(Guid bookingId, ChangeBookingTitleDto dto,
        CancellationToken cancellationToken);

    Task ChangeBookingDescriptionAsync(Guid bookingId,
        ChangeBookingDescriptionDto dto,
        CancellationToken cancellationToken);

    Task ChangeBookingScheduleAsync(Guid bookingId,
        ChangeBookingScheduleDto dto,
        CancellationToken cancellationToken);

    Task ChangeBookingRoomAsync(Guid bookingId, ChangeBookingRoomDto dto,
        CancellationToken cancellationToken);
}