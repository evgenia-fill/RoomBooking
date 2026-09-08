using RoomBooking.Contracts.Room;
using RoomBooking.Domain.Booking;
using RoomBooking.Domain.Room;

namespace RoomBooking.Application;

public class RoomsService
{
    private readonly IRoomRepository _roomRepository;
    private readonly IBookingRepository _bookingRepository;

    public RoomsService(IRoomRepository roomRepository, IBookingRepository bookingRepository)
    {
        _roomRepository = roomRepository;
        _bookingRepository = bookingRepository;
    }

    public async Task<Room?> GetByIdAsync(int roomId, CancellationToken cancellationToken)
    {
        return await _roomRepository.GetByIdAsync(roomId, cancellationToken);
    }

    public async Task<List<Room>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _roomRepository.GetAllAsync(cancellationToken);
    }

    public async Task CreateAsync(CreateRoomDto dto, CancellationToken cancellationToken)
    {
        var newRoom = new Room(dto.Name, dto.Capacity);
        await _roomRepository.AddAsync(newRoom, cancellationToken);
    }

    public async Task ChangeNameAsync(int roomId, ChangeRoomNameDto dto,
        CancellationToken cancellationToken)
    {
        var room = await _roomRepository.GetByIdAsync(roomId, cancellationToken);
        if (room == null) throw new KeyNotFoundException("Room not found");

        room.ChangeName(dto.Name);
        await _roomRepository.UpdateAsync(room, cancellationToken);
    }

    public async Task ChangeCapacityAsync(int roomId, ChangeRoomCapacityDto dto,
        CancellationToken cancellationToken)
    {
        var room = await _roomRepository.GetByIdAsync(roomId, cancellationToken);
        if (room == null) throw new KeyNotFoundException("Room not found");

        room.ChangeCapacity(dto.Capacity);
        await _roomRepository.UpdateAsync(room, cancellationToken);
    }

    public async Task<List<Booking>> GetRoomBookingsAsync(int roomId, CancellationToken cancellationToken)
    {
        var room = await _roomRepository.GetByIdAsync(roomId, cancellationToken);
        if (room == null) throw new KeyNotFoundException("Room not found");

        return await _bookingRepository.GetByRoomIdAsync(room.Id, cancellationToken);
    }

    public async Task DeleteAsync(int roomId, CancellationToken cancellationToken)
    {
        var room = await _roomRepository.GetByIdAsync(roomId, cancellationToken);
        if (room == null) throw new KeyNotFoundException("Room not found");

        room.Archive();
        await _roomRepository.UpdateAsync(room, cancellationToken);
    }
}