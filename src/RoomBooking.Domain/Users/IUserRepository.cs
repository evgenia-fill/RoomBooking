namespace RoomBooking.Domain.Users;

public interface IUserRepository
{
    Task<User?> GetByIdAsync(Guid userId, CancellationToken cancellationToken);
    
    Task<List<User>> GetAllAsync(CancellationToken cancellationToken);
    
    Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken);

    Task UpdateAsync(User user, CancellationToken cancellationToken);

    Task<User> AddAsync(User user, CancellationToken cancellationToken);

    Task DeleteAsync(Guid userId, CancellationToken cancellationToken);
}