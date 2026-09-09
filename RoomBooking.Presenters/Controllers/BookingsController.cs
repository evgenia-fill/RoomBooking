using Microsoft.AspNetCore.Mvc;
using RoomBooking.Contracts.Booking;

namespace RoomBooking.Presenters.Controllers;

[ApiController]
[Route("[controller]")]
public class BookingsController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateBookingDto dto, CancellationToken cancellationToken)
    {
        return Ok("Booking created");
    }

    [HttpPost("{bookingId:guid}/cancel")]
    public async Task<IActionResult> CancelBooking([FromRoute] Guid bookingId, CancellationToken cancellationToken)
    {
        return Ok("Booking cancelled");
    }

    [HttpGet("{bookingId:guid}")]
    public async Task<IActionResult> GetById([FromRoute] Guid bookingId, CancellationToken cancellationToken)
    {
        return Ok($"Booking {bookingId} has been retrieved");
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        return Ok("List of all bookings");
    }

    [HttpGet("{bookingId:guid}/bookings")]
    public async Task<IActionResult> GetByRoomId([FromRoute] int roomId,
        CancellationToken cancellationToken)
    {
        return Ok($"Bookings has been retrieved");
    }

    [HttpPatch("{bookingId:guid}/title")]
    public async Task<IActionResult> ChangeBookingTitle([FromRoute] Guid bookingId, [FromBody] ChangeBookingTitleDto dto,
        CancellationToken cancellationToken)
    {
        return Ok("Title has changed");
    }

    [HttpPatch("{bookingId:guid}/description")]
    public async Task<IActionResult> ChangeBookingDescription([FromRoute] Guid bookingId,
        [FromBody] ChangeBookingDescriptionDto dto,
        CancellationToken cancellationToken)
    {
        return Ok("Description has changed");
    }

    [HttpPatch("{bookingId:guid}/schedule")]
    public async Task<IActionResult> ChangeBookingSchedule([FromRoute] Guid bookingId,
        [FromBody] ChangeBookingScheduleDto dto,
        CancellationToken cancellationToken)
    {
        return Ok("Schedule has changed");
    }

    [HttpPatch("{bookingId:guid}/room")]
    public async Task<IActionResult> ChangeBookingRoom([FromRoute] Guid bookingId, [FromBody] ChangeBookingRoomDto dto,
        CancellationToken cancellationToken)
    {
        return Ok("Room has changed");
    }
}