using Microsoft.Extensions.Logging;
using RoomBooking.Contracts.Room;
using RoomBooking.Domain.Booking;
using RoomBooking.Domain.Room;

namespace RoomBooking.Application;

public class RoomsService
{
    private readonly IRoomRepository _roomRepository;
    private readonly IBookingRepository _bookingRepository;
    private readonly ILogger<RoomsService> _logger;

    public RoomsService(IRoomRepository roomRepository, IBookingRepository bookingRepository,
        ILogger<RoomsService> logger)
    {
        _roomRepository = roomRepository;
        _bookingRepository = bookingRepository;
        _logger = logger;
    }

    public async Task<Room> CreateAsync(CreateRoomDto dto, CancellationToken cancellationToken)
    {
        var room = new Room(dto.Name, dto.Capacity);
        var createdRoom = await _roomRepository.AddAsync(room, cancellationToken);
        _logger.LogInformation("Room created with Id: {RoomId}", createdRoom.Id);
        return createdRoom;
    }

    public async Task<Room?> GetByIdAsync(int roomId, CancellationToken cancellationToken)
    {
        return await _roomRepository.GetByIdAsync(roomId, cancellationToken);
    }

    public async Task<List<Room>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _roomRepository.GetAllAsync(cancellationToken);
    }

    public async Task ChangeNameAsync(int roomId, ChangeRoomNameDto dto,
        CancellationToken cancellationToken)
    {
        var room = await _roomRepository.GetByIdAsync(roomId, cancellationToken);
        if (room == null) throw new KeyNotFoundException("Room not found");

        room.ChangeName(dto.Name);
        await _roomRepository.UpdateAsync(room, cancellationToken);

        _logger.LogInformation("Room updated (changed name) with Id: {RoomId}", room.Id);
    }

    public async Task ChangeCapacityAsync(int roomId, ChangeRoomCapacityDto dto,
        CancellationToken cancellationToken)
    {
        var room = await _roomRepository.GetByIdAsync(roomId, cancellationToken);
        if (room == null) throw new KeyNotFoundException("Room not found");

        room.ChangeCapacity(dto.Capacity);
        await _roomRepository.UpdateAsync(room, cancellationToken);

        _logger.LogInformation("Room updated (changed capacity) with Id: {RoomId}", room.Id);
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

        _logger.LogInformation("Room deleted with Id: {RoomId}", room.Id);
    }
}