
using Carquitecture.Application.Features.Vehicles.Models;
using Carquitecture.Application.Repositories;
using Carquitecture.Application.Shared.ErrorHandling;
using Carquitecture.Domain;

namespace Carquitecture.Application.Features.Vehicles.UpdateVehicle.Commands;

public class UpdateVehicleCommandHandler : IUpdateVehicleCommandHandler
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateVehicleCommandHandler(IUnitOfWork unitOfWork)
    {
        ArgumentNullException.ThrowIfNull(unitOfWork, nameof(unitOfWork));
        _unitOfWork = unitOfWork;
    }
    public async Task<Result<VehicleDto>> HandleAsync(UpdateVehicleCommand command, CancellationToken cancellationToken)
    {
        var vehicle = await _unitOfWork.Vehicles.GetByIdAsync(command.Id, cancellationToken);

        if (vehicle is null)
        { 
            return Result<VehicleDto>.Failure(new Error("VehicleNotFound", $"Vehicle with id {command.Id} not found."));
        }

        var updatedVehicle = new Vehicle(command.Id, command.LicensePlate, command.Type, command.Owner);
         _unitOfWork.Vehicles.Update(updatedVehicle);

        await _unitOfWork.SaveChangesAsync();

        return Result<VehicleDto>.Success(new VehicleDto(updatedVehicle.Id, updatedVehicle.LicensePlate, updatedVehicle.Owner));
    }
}
