
using Carquitecture.Application.Features.Vehicles.Models;
using Carquitecture.Application.Repositories;
using Carquitecture.Application.Shared.ErrorHandling;

namespace Carquitecture.Application.Features.Vehicles.UpdateVehicle.Commands;

public class UpdateVehicleCommandHandler : IUpdateVehicleCommandHandler
{
    private readonly IVehicleRepository _vehicleRepository;

    public UpdateVehicleCommandHandler(IVehicleRepository vehicleRepository)
    {
        ArgumentNullException.ThrowIfNull(vehicleRepository, nameof(vehicleRepository));
        _vehicleRepository = vehicleRepository;
    }
    public async Task<Result<VehicleDto>> HandleAsync(UpdateVehicleCommand command, CancellationToken cancellationToken)
    {
        var vehicle = await _vehicleRepository.GetByIdAsync(command.Id, cancellationToken);

        if (vehicle is null)
        { 
            return Result<VehicleDto>.Failure(new Error("VehicleNotFound", $"Vehicle with id {command.Id} not found."));
        }

        vehicle.SetLicensePlate(command.LicensePlate);
        vehicle.SetOwner(command.Owner);
        vehicle.SetType(command.Type);

        return Result<VehicleDto>.Success(new VehicleDto(vehicle.Id, vehicle.LicensePlate, vehicle.Owner));
    }
}
