using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using RoomBooking.Application.Bookings;
using RoomBooking.Application.Rooms;
using RoomBooking.Application.Users;

namespace RoomBooking.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);

        services.AddScoped<IBookingService, BookingsService>();
        services.AddScoped<IRoomService, RoomsService>();
        services.AddScoped<IUsersService, UsersService>();
        
        return services;
    }
}
