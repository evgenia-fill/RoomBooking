using Microsoft.EntityFrameworkCore;
using RoomBooking.Domain.Bookings;
using RoomBooking.Domain.Rooms;
using RoomBooking.Domain.Users;

namespace RoomBooking.Infrastructure;

public interface IApplicationDbContext
{
    public DbSet<User> Users { get; }
    public DbSet<Room> Rooms { get; }
    public DbSet<Booking> Bookings { get; }
}