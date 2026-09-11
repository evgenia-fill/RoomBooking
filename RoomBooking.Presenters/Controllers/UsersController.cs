using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using RoomBooking.Application.Users;
using RoomBooking.Contracts.Users;

namespace RoomBooking.Presenters.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly UsersService _usersService;

    public UsersController(UsersService usersService)
    {
        _usersService = usersService;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateUserDto dto, CancellationToken cancellationToken)
    {
        var user = await _usersService.Create(dto, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { userId = user.Id }, user);
    }

    [HttpGet("{userId:guid}")]
    public async Task<IActionResult> GetById([FromRoute] Guid userId, CancellationToken cancellationToken)
    {
        var user = await _usersService.GetByIdAsync(userId, cancellationToken);
        return Ok(user);
    }

    [HttpGet("me")]
    public async Task<IActionResult> GetMe(CancellationToken cancellationToken)
    {
        var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (string.IsNullOrEmpty(userIdClaim) || !Guid.TryParse(userIdClaim, out var userId))
        {
            return Unauthorized();
        }

        var user = await _usersService.GetByIdAsync(userId, cancellationToken);
        return Ok(user);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var users = await _usersService.GetAllAsync(cancellationToken);
        return Ok(users);
    }

    [HttpGet("by-email")]
    public async Task<IActionResult> GetByEmail([FromQuery] string email, CancellationToken cancellationToken)
    {
        var user = await _usersService.GetByEmailAsync(email, cancellationToken);
        return Ok(user);
    }

    [HttpGet("{userId:guid}/bookings")]
    public async Task<IActionResult> GetUserBookings([FromRoute] Guid userId, CancellationToken cancellationToken)
    {
        var bookings = await _usersService.GetUserBookingsAsync(userId, cancellationToken);
        return Ok(bookings);
    }

    [HttpDelete("{userId:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid userId, CancellationToken cancellationToken)
    {
        await _usersService.Delete(userId, cancellationToken);
        return NoContent();
    }

    [HttpPatch("{userId:guid}/name")]
    public async Task<IActionResult> ChangeName([FromRoute] Guid userId, [FromBody] ChangeUserNameDto dto,
        CancellationToken cancellationToken)
    {
        await _usersService.ChangeNameAsync(userId, dto, cancellationToken);
        return NoContent();
    }

    [HttpPatch("{userId:guid}/email")]
    public async Task<IActionResult> ChangeEmail([FromRoute] Guid userId, [FromBody] ChangeUserEmailDto dto,
        CancellationToken cancellationToken)
    {
        await _usersService.ChangeEmailAsync(userId, dto, cancellationToken);
        return NoContent();
    }

    [HttpPatch("{userId:guid}/password")]
    public async Task<IActionResult> ChangePassword([FromRoute] Guid userId, [FromBody] ChangeUserPasswordDto dto,
        CancellationToken cancellationToken)
    {
        await _usersService.ChangePasswordAsync(userId, dto, cancellationToken);
        return NoContent();
    }
}