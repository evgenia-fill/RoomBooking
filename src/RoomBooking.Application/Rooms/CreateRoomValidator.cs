using FluentValidation;
using RoomBooking.Contracts.Rooms;

namespace RoomBooking.Application.Rooms;

public class CreateRoomValidator : AbstractValidator<CreateRoomDto>
{
    public CreateRoomValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name cannot be empty.");
        
        RuleFor(x => x.Capacity)
            .GreaterThan(1).WithMessage("Capacity must be greater than 1.");
    }
}