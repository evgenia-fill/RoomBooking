using FluentValidation;
using RoomBooking.Contracts.Rooms;

namespace RoomBooking.Application.Rooms;

public class ChangeRoomNameValidator : AbstractValidator<ChangeRoomNameDto>
{
    public ChangeRoomNameValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name cannot be empty.");
    }
}