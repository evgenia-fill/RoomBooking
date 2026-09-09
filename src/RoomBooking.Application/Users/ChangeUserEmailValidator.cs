using FluentValidation;
using RoomBooking.Contracts.Users;

namespace RoomBooking.Application.Users;

public class ChangeUserEmailValidator : AbstractValidator<ChangeUserEmailDto>
{
    public ChangeUserEmailValidator()
    {
        RuleFor(x => x.Email).EmailAddress().WithMessage("Invalid email address.");
    }
}