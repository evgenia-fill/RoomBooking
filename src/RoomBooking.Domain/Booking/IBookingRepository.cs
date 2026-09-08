namespace RoomBooking.Domain.Booking;

public interface IBookingRepository
{
    Task<Booking> AddAsync(Booking booking, CancellationToken cancellationToken);

    Task DeleteAsync(int bookingId, CancellationToken cancellationToken);

    Task<Booking?> GetByIdAsync(int bookingId, CancellationToken cancellationToken);

    Task<List<Booking>> GetAllAsync(CancellationToken cancellationToken);

    Task UpdateAsync(Booking booking, CancellationToken cancellationToken);
}