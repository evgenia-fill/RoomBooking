using Microsoft.AspNetCore.Mvc;
using RoomBooking.Contracts.User;

namespace RoomBooking.Presenters.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    [HttpGet("{userId:guid}")]
    public async Task<IActionResult> GetById([FromRoute] Guid userId, CancellationToken cancellationToken)
    {
        return Ok();
    }

    [HttpGet("me")]
    public async Task<IActionResult> GetMe(CancellationToken cancellationToken)
    {
        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        return Ok();
    }

    [HttpGet("by-email")]
    public async Task<IActionResult> GetByEmail([FromQuery] string email, CancellationToken cancellationToken)
    {
        return Ok();
    }

    [HttpPatch("{userId:guid}/name")]
    public async Task<IActionResult> ChangeName([FromRoute] Guid userId, [FromBody] ChangeUserNameDto dto,
        CancellationToken cancellationToken)
    {
        return Ok();
    }

    [HttpPatch("{userId:guid}/email")]
    public async Task<IActionResult> ChangeEmail([FromRoute] Guid userId, [FromBody] ChangeUserEmailDto dto,
        CancellationToken cancellationToken)
    {
        return Ok();
    }

    [HttpPatch("{userId:guid}/password")]
    public async Task<IActionResult> ChangePassword([FromRoute] Guid userId, [FromBody] ChangeUserPasswordDto dto,
        CancellationToken cancellationToken)
    {
        return Ok();
    }

    [HttpGet("{userId:guid}/bookings")]
    public async Task<IActionResult> GetUserBookings([FromRoute] Guid userId, CancellationToken cancellationToken)
    {
        return Ok();
    }
}