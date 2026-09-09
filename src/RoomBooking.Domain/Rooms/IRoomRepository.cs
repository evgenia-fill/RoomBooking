namespace RoomBooking.Domain.Rooms;

public interface IRoomRepository
{
    Task<Room?> GetByIdAsync(int roomId, CancellationToken cancellationToken);

    Task<List<Room>> GetAllAsync(CancellationToken cancellationToken);

    Task UpdateAsync(Room room, CancellationToken cancellationToken);

    Task<Room> AddAsync(Room room, CancellationToken cancellationToken);

    Task DeleteAsync(Room room, CancellationToken cancellationToken);
}