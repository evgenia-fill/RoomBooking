using Microsoft.AspNetCore.Mvc;
using RoomBooking.Application.Rooms;
using RoomBooking.Contracts.Rooms;

namespace RoomBooking.Presenters.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RoomsController : ControllerBase
{
    private readonly RoomsService _roomsService;

    public RoomsController(RoomsService roomsService)
    {
        _roomsService = roomsService;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateRoomDto dto, CancellationToken cancellationToken)
    {
        var room = await _roomsService.CreateAsync(dto, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id = room.Id }, room);
    }

    [HttpGet("{roomId}:int")]
    public async Task<IActionResult> GetById([FromRoute] int roomId, CancellationToken cancellationToken)
    {
        var room = await _roomsService.GetByIdAsync(roomId, cancellationToken);
        return Ok(new { Room = room });
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var rooms = await _roomsService.GetAllAsync(cancellationToken);
        return Ok(rooms);
    }

    [HttpGet("{roomId:int}/bookings")]
    public async Task<IActionResult> GetRoomBookings([FromRoute] int roomId, CancellationToken cancellationToken)
    {
        var bookings = await _roomsService.GetRoomBookingsAsync(roomId, cancellationToken);
        return Ok(bookings);
    }

    [HttpDelete("{roomId:int}")]
    public async Task<IActionResult> Delete([FromRoute] int roomId, CancellationToken cancellationToken)
    {
        await _roomsService.DeleteAsync(roomId, cancellationToken);
        return NoContent();
    }

    [HttpPatch("{roomId:int}/name")]
    public async Task<IActionResult> ChangeName([FromRoute] int roomId, [FromBody] ChangeRoomNameDto dto,
        CancellationToken cancellationToken)
    {
        await _roomsService.ChangeNameAsync(roomId, dto, cancellationToken);
        return NoContent();
    }

    [HttpPatch("{roomId:int}/capacity")]
    public async Task<IActionResult> ChangeCapacity([FromRoute] int roomId, [FromBody] ChangeRoomCapacityDto dto,
        CancellationToken cancellationToken)
    {
        await _roomsService.ChangeCapacityAsync(roomId, dto, cancellationToken);
        return NoContent();
    }
}