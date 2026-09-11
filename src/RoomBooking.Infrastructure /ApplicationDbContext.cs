using Microsoft.EntityFrameworkCore;
using RoomBooking.Domain;
using RoomBooking.Domain.Bookings;
using RoomBooking.Domain.Rooms;
using RoomBooking.Domain.Users;

namespace RoomBooking.Infrastructure;

public class ApplicationDbContext : DbContext, IUnitOfWork, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Booking> Bookings { get; set; }
}