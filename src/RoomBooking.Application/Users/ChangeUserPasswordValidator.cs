using FluentValidation;
using RoomBooking.Contracts.Users;

namespace RoomBooking.Application.Users;

public class ChangeUserPasswordValidator : AbstractValidator<ChangeUserPasswordDto>
{
    public ChangeUserPasswordValidator()
    {
        RuleFor(x => x.PasswordHash)
            .NotEmpty().WithMessage("Password cannot be empty.")
            .MinimumLength(6).WithMessage("Password must be at least 6 characters long.");
    }
}