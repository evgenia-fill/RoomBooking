using FluentValidation;
using RoomBooking.Contracts.Rooms;

namespace RoomBooking.Application.Rooms;

public class ChangeRoomCapacityValidator : AbstractValidator<ChangeRoomCapacityDto>
{
    public ChangeRoomCapacityValidator()
    {
        RuleFor(x => x.Capacity).GreaterThan(1).WithMessage("Capacity must be greater than 1.");
    }
}