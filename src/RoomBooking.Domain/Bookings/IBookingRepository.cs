namespace RoomBooking.Domain.Bookings;

public interface IBookingRepository
{
    Task<Bookings.Booking> AddAsync(Bookings.Booking booking, CancellationToken cancellationToken);

    Task DeleteAsync(int bookingId, CancellationToken cancellationToken);

    Task<Bookings.Booking?> GetByIdAsync(int bookingId, CancellationToken cancellationToken);

    Task<List<Bookings.Booking>> GetAllAsync(CancellationToken cancellationToken);

    Task<List<Bookings.Booking>> GetByRoomIdAsync(int roomId, CancellationToken cancellationToken);
    
    Task<List<Bookings.Booking>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken);

    Task UpdateAsync(Bookings.Booking booking, CancellationToken cancellationToken);
}