using FluentValidation;
using RoomBooking.Contracts.Users;

namespace RoomBooking.Application.Users;

public class ChangeUserNameValidator : AbstractValidator<ChangeUserNameDto>
{
    public ChangeUserNameValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name cannot be empty.");
    }
}