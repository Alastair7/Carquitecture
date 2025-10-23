using FluentValidation;

namespace Carquitecture.Application.Features.Vehicles.CreateVehicle.Commands;

public sealed class CreateVehicleCommandValidator : AbstractValidator<CreateVehicleCommand>
{
    public CreateVehicleCommandValidator() 
    {
        RuleFor(x => x.LicensePlate).NotEmpty().WithMessage("License plate is required.")
            .MaximumLength(10).WithMessage("License plate cannot exceed 10 characters.");

        RuleFor(x => x.Type).NotEmpty().WithMessage("Vehicle type is required.");
    }
}
