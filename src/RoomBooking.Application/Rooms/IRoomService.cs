using RoomBooking.Contracts.Rooms;
using RoomBooking.Domain.Bookings;
using RoomBooking.Domain.Rooms;

namespace RoomBooking.Application.Rooms;

public interface IRoomService
{
    Task<Room> CreateAsync(CreateRoomDto dto, CancellationToken cancellationToken);

    Task<Room?> GetByIdAsync(int roomId, CancellationToken cancellationToken);

    Task<List<Room>> GetAllAsync(CancellationToken cancellationToken);

    Task ChangeNameAsync(int roomId, ChangeRoomNameDto dto,
        CancellationToken cancellationToken);

    Task ChangeCapacityAsync(int roomId, ChangeRoomCapacityDto dto,
        CancellationToken cancellationToken);

    Task<List<Booking>> GetRoomBookingsAsync(int roomId, CancellationToken cancellationToken);

    Task DeleteAsync(int roomId, CancellationToken cancellationToken);
}