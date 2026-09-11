using FluentValidation;
using RoomBooking.Contracts.Bookings;

namespace RoomBooking.Application.Bookings;

public class ChangeBookingScheduleValidator : AbstractValidator<ChangeBookingScheduleDto>
{
    public ChangeBookingScheduleValidator()
    {
        RuleFor(x => x.StartTime)
            .NotEmpty().WithMessage("Start time cannot be empty.");

        RuleFor(x => x.EndTime)
            .NotEmpty().WithMessage("End time cannot be empty.")
            .GreaterThan(x => x.StartTime)
            .WithMessage("End time must be greater than start time.");
    }
}