using FluentValidation;
using RoomBooking.Contracts.Bookings;

namespace RoomBooking.Application.Bookings;

public class ChangeBookingRoomValidator : AbstractValidator<ChangeBookingRoomDto>
{
    public ChangeBookingRoomValidator()
    {
        RuleFor(x => x.RoomId).GreaterThan(0).WithMessage("Room id must be greater than zero.");
    }
}