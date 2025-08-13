
using Carquitecture.Application.Repositories;
using Carquitecture.Domain;

namespace Carquitecture.Application.Features.Vehicles.CreateVehicle.Commands;

public class CreateVehicleCommandHandler : ICreateVehicleCommandHandler
{
    private readonly IVehicleRepository _vehicleRepository;

    public CreateVehicleCommandHandler(IVehicleRepository vehicleRepository)
    {
        ArgumentNullException.ThrowIfNull(vehicleRepository, nameof(vehicleRepository));
        _vehicleRepository = vehicleRepository;
    }

    public async Task<int> HandleAsync(CreateVehicleCommand command, CancellationToken cancellationToken)
    {
        var vehicle = new Vehicle(command.Id, command.LicensePlate, command.Type, command.Owner);

        return await _vehicleRepository.CreateAsync(vehicle, cancellationToken);
    }
}
