namespace RoomBooking.Domain.Entities;

public class Room
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public int Capacity { get; private set; }

    public Room(string name, int capacity)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name cannot be null or whitespace.", nameof(name));
        if (capacity < 1) throw new ArgumentException("Capacity cannot be less than 1.", nameof(capacity));

        Name = name;
        Capacity = capacity;
    }
}