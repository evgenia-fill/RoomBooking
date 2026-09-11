using Microsoft.AspNetCore.Mvc;
using RoomBooking.Application.Bookings;
using RoomBooking.Contracts.Bookings;

namespace RoomBooking.Presenters.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookingsController : ControllerBase
{
    private readonly IBookingService _bookingService;

    public BookingsController(IBookingService bookingService)
    {
        _bookingService = bookingService;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateBookingDto dto, CancellationToken cancellationToken)
    {
        var booking = await _bookingService.CreateAsync(dto, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { bookingId = booking.Id }, booking);
    }

    [HttpPost("{bookingId:guid}/cancel")]
    public async Task<IActionResult> CancelBooking([FromRoute] Guid bookingId, CancellationToken cancellationToken)
    {
        await _bookingService.CancelBookingAsync(bookingId, cancellationToken);
        return NoContent();
    }

    [HttpGet("{bookingId:guid}")]
    public async Task<IActionResult> GetById([FromRoute] Guid bookingId, CancellationToken cancellationToken)
    {
        var booking = await _bookingService.GetByIdAsync(bookingId, cancellationToken);
        return Ok(booking);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var bookings = await _bookingService.GetAllAsync(cancellationToken);
        return Ok(bookings);
    }

    [HttpGet("{roomId:int}/bookings")]
    public async Task<IActionResult> GetByRoomId([FromRoute] int roomId,
        CancellationToken cancellationToken)
    {
        var bookings = await _bookingService.GetByRoomIdAsync(roomId, cancellationToken);
        return Ok(bookings);
    }

    [HttpPatch("{bookingId:guid}/title")]
    public async Task<IActionResult> ChangeBookingTitle([FromRoute] Guid bookingId,
        [FromBody] ChangeBookingTitleDto dto,
        CancellationToken cancellationToken)
    {
        await _bookingService.ChangeBookingTitleAsync(bookingId, dto, cancellationToken);
        return NoContent();
    }

    [HttpPatch("{bookingId:guid}/description")]
    public async Task<IActionResult> ChangeBookingDescription([FromRoute] Guid bookingId,
        [FromBody] ChangeBookingDescriptionDto dto,
        CancellationToken cancellationToken)
    {
        await _bookingService.ChangeBookingDescriptionAsync(bookingId, dto, cancellationToken);
        return NoContent();
    }

    [HttpPatch("{bookingId:guid}/schedule")]
    public async Task<IActionResult> ChangeBookingSchedule([FromRoute] Guid bookingId,
        [FromBody] ChangeBookingScheduleDto dto,
        CancellationToken cancellationToken)
    {
        await _bookingService.ChangeBookingScheduleAsync(bookingId, dto, cancellationToken);
        return NoContent();
    }

    [HttpPatch("{bookingId:guid}/room")]
    public async Task<IActionResult> ChangeBookingRoom([FromRoute] Guid bookingId, [FromBody] ChangeBookingRoomDto dto,
        CancellationToken cancellationToken)
    {
        await _bookingService.ChangeBookingRoomAsync(bookingId, dto, cancellationToken);
        return NoContent();
    }
}