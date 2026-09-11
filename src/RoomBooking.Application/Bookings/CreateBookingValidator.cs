using FluentValidation;
using RoomBooking.Contracts.Bookings;

namespace RoomBooking.Application.Bookings;

public class CreateBookingValidator : AbstractValidator<CreateBookingDto>
{
    public CreateBookingValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage("UserId cannot be empty.");

        RuleFor(x => x.RoomId)
            .GreaterThan(0).WithMessage("Room ID must be greater than 0.");

        RuleFor(x => x.StartTime)
            .NotEmpty().WithMessage("Start time cannot be empty.");

        RuleFor(x => x.EndTime)
            .NotEmpty().WithMessage("End time cannot be empty.")
            .GreaterThan(x => x.StartTime)
            .WithMessage("End time must be greater than start time.");

        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title cannot be empty.");
    }
}