namespace RoomBooking.Domain.Entities;

public class Booking
{
    public int Id { get; private set; }
    public string Title { get; private set; }
    public string? Description { get; private set; }
    public Guid UserId { get; private set; }
    public int RoomId { get; private set; }
    public DateTimeOffset StartTime { get; private set; }
    public DateTimeOffset EndTime { get; private set; }
    public BookingStatus Status { get; private set; }

    public Booking(string title, string? description, Guid userId, int roomId, DateTimeOffset startTime, DateTimeOffset endTime)
    {
        if (userId == Guid.Empty) throw new ArgumentException("User ID cannot be empty.", nameof(userId));
        if (roomId <= 0) throw new ArgumentOutOfRangeException(nameof(roomId), "Room ID must be greater than 0.");
        if (string.IsNullOrWhiteSpace(title)) throw new ArgumentNullException(nameof(title), "Title cannot be empty.");
        if (endTime <= startTime) throw new ArgumentException("End time must be greater than start time.");

        UserId = userId;
        RoomId = roomId;
        Title = title;
        Description = description;
        StartTime = startTime;
        EndTime = endTime;
        Status = BookingStatus.Active;
    }
}