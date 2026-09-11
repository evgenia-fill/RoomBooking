namespace RoomBooking.Domain.Bookings;

public interface IBookingRepository
{
    Task<Booking> AddAsync(Booking booking, CancellationToken cancellationToken);

    Task DeleteAsync(Guid bookingId, CancellationToken cancellationToken);

    Task<Booking?> GetByIdAsync(Guid bookingId, CancellationToken cancellationToken);

    Task<List<Booking>> GetAllAsync(CancellationToken cancellationToken);

    Task<List<Booking>> GetByRoomIdAsync(int roomId, CancellationToken cancellationToken);

    Task<List<Booking>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken);
}