using RoomBooking.Contracts.Users;
using RoomBooking.Domain.Bookings;
using RoomBooking.Domain.Users;

namespace RoomBooking.Application.Users;

public interface IUsersService
{
    Task<User> Create(CreateUserDto dto, CancellationToken cancellationToken);

    Task<User?> GetByIdAsync(Guid userId, CancellationToken cancellationToken);

    Task<List<User>> GetAllAsync(CancellationToken cancellationToken);

    Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken);

    Task<List<Booking>> GetUserBookingsAsync(Guid userId, CancellationToken cancellationToken);

    Task Delete(Guid userId, CancellationToken cancellationToken);

    Task ChangeNameAsync(Guid userId, ChangeUserNameDto dto,
        CancellationToken cancellationToken);

    Task ChangeEmailAsync(Guid userId, ChangeUserEmailDto dto,
        CancellationToken cancellationToken);

    Task ChangePasswordAsync(Guid userId, ChangeUserPasswordDto dto,
        CancellationToken cancellationToken);
}