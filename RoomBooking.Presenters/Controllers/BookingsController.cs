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

    [HttpPost("{bookingId:int}/cancel")]
    public async Task<IActionResult> CancelBooking([FromRoute] int bookingId, CancellationToken cancellationToken)
    {
        return Ok("Booking cancelled");
    }

    [HttpGet("{bookingId:int}")]
    public async Task<IActionResult> GetById([FromRoute] int bookingId, CancellationToken cancellationToken)
    {
        return Ok($"Booking {bookingId} has been retrieved");
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        return Ok("List of all bookings");
    }

    [HttpGet("{bookingId:int}/bookings")]
    public async Task<IActionResult> GetByRoomId([FromRoute] int roomId,
        CancellationToken cancellationToken)
    {
        return Ok($"Bookings has been retrieved");
    }

    [HttpPatch("{bookingId:int}/title")]
    public async Task<IActionResult> ChangeBookingTitle([FromRoute] int bookingId, [FromBody] ChangeBookingTitleDto dto,
        CancellationToken cancellationToken)
    {
        return Ok("Title has changed");
    }

    [HttpPatch("{bookingId:int}/description")]
    public async Task<IActionResult> ChangeBookingDescription([FromRoute] int bookingId,
        [FromBody] ChangeBookingDescriptionDto dto,
        CancellationToken cancellationToken)
    {
        return Ok("Description has changed");
    }

    [HttpPatch("{bookingId:int}/schedule")]
    public async Task<IActionResult> ChangeBookingSchedule([FromRoute] int bookingId,
        [FromBody] ChangeBookingScheduleDto dto,
        CancellationToken cancellationToken)
    {
        return Ok("Schedule has changed");
    }

    [HttpPatch("{bookingId:int}/room")]
    public async Task<IActionResult> ChangeBookingRoom([FromRoute] int bookingId, [FromBody] ChangeBookingRoomDto dto,
        CancellationToken cancellationToken)
    {
        return Ok("Room has changed");
    }
}