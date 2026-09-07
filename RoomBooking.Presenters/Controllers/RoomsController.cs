using Microsoft.AspNetCore.Mvc;
using RoomBooking.Contracts.Room;

namespace RoomBooking.Presenters.Controllers;

[ApiController]
[Route("[controller]")]
public class RoomsController : ControllerBase
{
    [HttpGet("{roomId}:int}")]
    public async Task<IActionResult> GetById([FromRoute] int roomId, CancellationToken cancellationToken)
    {
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateRoomDto dto, CancellationToken cancellationToken)
    {
        return Ok();
    }

    [HttpPatch("{id:int}/name")]
    public async Task<IActionResult> ChangeName([FromRoute] int id, [FromBody] ChangeRoomNameDto dto,
        CancellationToken cancellationToken)
    {
        return Ok();
    }

    [HttpGet("{roomId:int}/bookings")]
    public async Task<IActionResult> GetBookings([FromRoute] int roomId, CancellationToken cancellationToken)
    {
        return Ok();
    }

    [HttpDelete("{roomId:int}")]
    public async Task<IActionResult> Delete([FromRoute] int roomId, CancellationToken cancellationToken)
    {
        return Ok();
    }
}