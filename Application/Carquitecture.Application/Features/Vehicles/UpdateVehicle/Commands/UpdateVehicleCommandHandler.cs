
using Carquitecture.Application.Features.Vehicles.Models;
using Carquitecture.Application.Repositories;
using Carquitecture.Domain;

namespace Carquitecture.Application.Features.Vehicles.UpdateVehicle.Commands;

public class UpdateVehicleCommandHandler : IUpdateVehicleCommandHandler
{
    private readonly IVehicleRepository _vehicleRepository;

    public UpdateVehicleCommandHandler(IVehicleRepository vehicleRepository)
    {
        ArgumentNullException.ThrowIfNull(vehicleRepository, nameof(vehicleRepository));
        _vehicleRepository = vehicleRepository;
    }
    public async Task<VehicleDto> HandleAsync(UpdateVehicleCommand command, CancellationToken cancellationToken)
    {
        var vehicle = await _vehicleRepository.GetById(command.Id, cancellationToken);

        if (vehicle is null)
        { 
            throw new Exception($"Vehicle with id {command.Id} not found.");
        }

        var updatedVehicle = new Vehicle(command.Id, command.LicensePlate, command.Type, command.Owner);
        await _vehicleRepository.UpdateAsync(updatedVehicle, cancellationToken);

        return new VehicleDto(updatedVehicle.Id, updatedVehicle.LicensePlate, updatedVehicle.Owner);
    }
}
