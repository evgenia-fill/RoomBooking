namespace RoomBooking.Domain.Bookings;

public class Booking
{
    public Guid Id { get; }
    public string Title { get; private set; }
    public string? Description { get; private set; }
    public Guid UserId { get; private set; }
    public int RoomId { get; private set; }
    public DateTimeOffset StartTime { get; private set; }
    public DateTimeOffset EndTime { get; private set; }
    public BookingStatus Status { get; private set; }

    public Booking(string title, string? description, Guid userId, int roomId, DateTimeOffset startTime,
        DateTimeOffset endTime)
    {
        if (userId == Guid.Empty) throw new ArgumentException("User ID cannot be empty.", nameof(userId));
        if (roomId <= 0) throw new ArgumentOutOfRangeException(nameof(roomId), "Room ID must be greater than 0.");
        if (string.IsNullOrWhiteSpace(title)) throw new ArgumentNullException(nameof(title), "Title cannot be empty.");
        if (endTime <= startTime) throw new ArgumentException("End time must be greater than start time.");

        Id = Guid.NewGuid();
        Title = title;
        Description = description;
        UserId = userId;
        RoomId = roomId;
        StartTime = startTime;
        EndTime = endTime;
        Status = BookingStatus.Active;
    }

    public void ChangeTitle(string newTitle)
    {
        if (string.IsNullOrWhiteSpace(newTitle))
            throw new ArgumentException("Title cannot be empty.", nameof(newTitle));
        Title = newTitle;
    }

    public void ChangeDescription(string newDescription)
    {
        Description = newDescription;
    }

    public void ChangeSchedule(DateTimeOffset newStartTime, DateTimeOffset newEndTime)
    {
        if (newEndTime <= newStartTime)
            throw new ArgumentException("End time must be greater than start time.");

        StartTime = newStartTime;
        EndTime = newEndTime;
    }

    public void ChangeRoom(int roomId)
    {
        if (roomId == 0) throw new ArgumentException("Room ID cannot be empty.", nameof(roomId));
        RoomId = roomId;
    }

    public void Cancel()
    {
        Status = BookingStatus.Cancelled;
    }
}