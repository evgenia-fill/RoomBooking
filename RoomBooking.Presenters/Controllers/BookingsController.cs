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
    public async Task<IActionResult> CancelBooking([FromRoute] int bookingId)
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

    [HttpPatch("{bookingId:int}/startTime")]
    public async Task<IActionResult> ChangeBookingStartTime([FromRoute] int bookingId,
        [FromBody] ChangeBookingStartTimeDto dto,
        CancellationToken cancellationToken)
    {
        return Ok("StartTime has changed");
    }

    [HttpPatch("{bookingId:int}/endTime")]
    public async Task<IActionResult> ChangeBookingEndTime([FromRoute] int bookingId,
        [FromBody] ChangeBookingEndTimeDto dto,
        CancellationToken cancellationToken)
    {
        return Ok("EndTime has changed");
    }

    [HttpPatch("{bookingId:int}/room")]
    public async Task<IActionResult> ChangeBookingRoom([FromRoute] int bookingId, [FromBody] ChangeBookingRoomDto dto,
        CancellationToken cancellationToken)
    {
        return Ok("Room has changed");
    }
}