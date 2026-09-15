using Microsoft.EntityFrameworkCore;
using RoomBooking.Domain.Rooms;

namespace RoomBooking.Infrastructure.Repositories;

public class RoomRepository : IRoomRepository
{
    private readonly IApplicationDbContext _dbContext;

    public RoomRepository(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Room> AddAsync(Room room, CancellationToken cancellationToken)
    {
        await _dbContext.Rooms.AddAsync(room, cancellationToken);
        return room;
    }

    public async Task<Room?> GetByIdAsync(int roomId, CancellationToken cancellationToken)
    {
        return await _dbContext.Rooms
            .Include(r => r.Bookings)
            .FirstOrDefaultAsync(r => r.Id == roomId, cancellationToken);
    }

    public async Task<List<Room>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _dbContext.Rooms
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    public Task DeleteAsync(Room room, CancellationToken cancellationToken)
    {
        _dbContext.Rooms.Remove(room);
        return Task.CompletedTask;
    }
}