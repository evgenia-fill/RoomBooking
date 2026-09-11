using Microsoft.EntityFrameworkCore;
using RoomBooking.Domain.Bookings;

namespace RoomBooking.Infrastructure.Repositories;

public class BookingRepository : IBookingRepository
{
    private readonly IApplicationDbContext _dbContext;

    public BookingRepository(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Booking> AddAsync(Booking booking, CancellationToken cancellationToken)
    {
        await _dbContext.Bookings.AddAsync(booking, cancellationToken);
        return booking;
    }

    public async Task DeleteAsync(Guid bookingId, CancellationToken cancellationToken)
    {
        var booking = await _dbContext.Bookings.FindAsync(bookingId, cancellationToken);
        if (booking != null)
        {
            _dbContext.Bookings.Remove(booking);
        }
    }

    public async Task<Booking?> GetByIdAsync(Guid bookingId, CancellationToken cancellationToken)
    {
        var booking = await _dbContext.Bookings.FindAsync(bookingId, cancellationToken);
        return booking;
    }

    public async Task<List<Booking>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _dbContext.Bookings.ToListAsync(cancellationToken);
    }

    public async Task<List<Booking>> GetByRoomIdAsync(int roomId, CancellationToken cancellationToken)
    {
        return await _dbContext.Bookings
            .Where(b => b.RoomId == roomId)
            .ToListAsync(cancellationToken);
    }

    public async Task<List<Booking>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken)
    {
        return await _dbContext.Bookings
            .Where(b => b.UserId == userId)
            .ToListAsync(cancellationToken);
    }
}