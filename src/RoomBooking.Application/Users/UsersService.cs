using Microsoft.Extensions.Logging;
using RoomBooking.Contracts.Users;
using RoomBooking.Domain.Bookings;
using RoomBooking.Domain.Users;

namespace RoomBooking.Application.Users;

public class UsersService : IUsersService
{
    private readonly IUserRepository _userRepository;
    private readonly IBookingRepository _bookingRepository;
    private readonly ILogger<UsersService> _logger;

    public UsersService(IUserRepository userRepository, IBookingRepository bookingRepository,
        ILogger<UsersService> logger)
    {
        _userRepository = userRepository;
        _bookingRepository = bookingRepository;
        _logger = logger;
    }

    public async Task<User> Create(CreateUserDto dto, CancellationToken cancellationToken)
    {
        var existingUser = await _userRepository.GetByEmailAsync(dto.Email, cancellationToken);
        if (existingUser != null) throw new Exception("User is already exist");

        var user = new User(dto.Name, dto.Email, dto.PasswordHash);
        _logger.LogInformation("User created with Id: {UserId}", user.Id);
        return await _userRepository.AddAsync(user, cancellationToken);
    }

    public async Task<User?> GetByIdAsync(Guid userId, CancellationToken cancellationToken)
    {
        return await _userRepository.GetByIdAsync(userId, cancellationToken);
    }


    public async Task<List<User>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _userRepository.GetAllAsync(cancellationToken);
    }

    public async Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken)
    {
        return await _userRepository.GetByEmailAsync(email, cancellationToken);
    }

    public async Task<List<Booking>> GetUserBookingsAsync(Guid userId, CancellationToken cancellationToken)
    {
        return await _bookingRepository.GetByUserIdAsync(userId, cancellationToken);
    }

    public async Task Delete(Guid userId, CancellationToken cancellationToken)
    {
        await _userRepository.DeleteAsync(userId, cancellationToken);
        _logger.LogInformation("User deleted with Id: {UserId}", userId);
    }

    public async Task ChangeNameAsync(Guid userId, ChangeUserNameDto dto,
        CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(userId, cancellationToken);
        if (user == null) throw new KeyNotFoundException("User not found");

        user.ChangeName(dto.Name);
        await _userRepository.UpdateAsync(user, cancellationToken);

        _logger.LogInformation("User updated (changed name) with Id: {UserId}", user.Id);
    }

    public async Task ChangeEmailAsync(Guid userId, ChangeUserEmailDto dto,
        CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(userId, cancellationToken);
        if (user == null) throw new KeyNotFoundException("User not found");

        var existingUser = await _userRepository.GetByEmailAsync(dto.Email, cancellationToken);
        if (existingUser != null) throw new Exception("User is already exist");

        user.ChangeEmail(dto.Email);
        await _userRepository.UpdateAsync(user, cancellationToken);

        _logger.LogInformation("User updated (changed email) with Id: {UserId}", user.Id);
    }

    public async Task ChangePasswordAsync(Guid userId, ChangeUserPasswordDto dto,
        CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(userId, cancellationToken);
        if (user == null) throw new KeyNotFoundException("User not found");

        user.ChangePassword(dto.PasswordHash);
        await _userRepository.UpdateAsync(user, cancellationToken);

        _logger.LogInformation("User updated (changed passwordHash) with Id: {UserId}", user.Id);
    }
}