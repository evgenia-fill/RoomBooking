using FluentValidation;
using RoomBooking.Contracts.Bookings;

namespace RoomBooking.Application.Bookings;

public class ChangeBookingTitleValidator : AbstractValidator<ChangeBookingTitleDto>
{
    public ChangeBookingTitleValidator()
    {
        RuleFor(x => x.Title).NotEmpty().WithMessage("Title cannot be empty.");
    }
}