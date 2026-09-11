using FluentValidation;
using RoomBooking.Contracts.Users;

namespace RoomBooking.Application.Users;

public class CreateUserValidator : AbstractValidator<CreateUserDto>
{
    public CreateUserValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name cannot be empty.");

        RuleFor(x => x.Email).EmailAddress().WithMessage("Invalid email address.");

        RuleFor(x => x.PasswordHash)
            .NotEmpty().WithMessage("Password cannot be empty.")
            .MinimumLength(6).WithMessage("Password must be at least 6 characters long.");
    }
}