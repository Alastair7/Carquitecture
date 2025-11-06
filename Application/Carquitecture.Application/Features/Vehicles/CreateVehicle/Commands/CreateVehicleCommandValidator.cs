using FluentValidation;

namespace Carquitecture.Application.Features.Vehicles.CreateVehicle.Commands;

public sealed class CreateVehicleCommandValidator : AbstractValidator<CreateVehicleCommand>
{
    public CreateVehicleCommandValidator() 
    {
        RuleFor(x => x.LicensePlate.PlateNumber).NotEmpty().WithMessage("Plate number is required.")
            .MaximumLength(10).WithMessage("Plate number cannot exceed 10 characters.");

        RuleFor(x => x.LicensePlate.Country).NotEmpty().WithMessage("Plate Country is required.")
            .MaximumLength(2).WithMessage("Plate Country cannot exceed 2 characters.");

        RuleFor(x => x.Type).NotEmpty().WithMessage("Vehicle type is required.");
    }
}
