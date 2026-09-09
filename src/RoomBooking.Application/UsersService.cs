using RoomBooking.Contracts.User;
using RoomBooking.Domain.Booking;
using RoomBooking.Domain.User;

namespace RoomBooking.Application;

public class UsersService
{
    private readonly IUserRepository _userRepository;
    private readonly IBookingRepository _bookingRepository;

    public UsersService(IUserRepository userRepository, IBookingRepository bookingRepository)
    {
        _userRepository = userRepository;
        _bookingRepository = bookingRepository;
    }

    public async Task<User> Create(CreateUserDto dto, CancellationToken cancellationToken)
    {
        var existingUser = await _userRepository.GetByEmailAsync(dto.Email, cancellationToken);
        if (existingUser != null) throw new Exception("User is already exist");

        var user = new User(dto.Name, dto.Email, dto.PasswordHash);
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
    }

    public async Task ChangeNameAsync(Guid userId, ChangeUserNameDto dto,
        CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(userId, cancellationToken);
        if (user == null) throw new KeyNotFoundException("User not found");

        user.ChangeName(dto.Name);
        await _userRepository.UpdateAsync(user, cancellationToken);
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
    }

    public async Task ChangePasswordAsync(Guid userId, ChangeUserPasswordDto dto,
        CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(userId, cancellationToken);
        if (user == null) throw new KeyNotFoundException("User not found");

        user.ChangePassword(dto.PasswordHash);
        await _userRepository.UpdateAsync(user, cancellationToken);
    }
}