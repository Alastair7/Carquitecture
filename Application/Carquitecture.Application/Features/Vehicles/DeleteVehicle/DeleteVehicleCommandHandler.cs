
using Carquitecture.Application.Repositories;

namespace Carquitecture.Application.Features.Vehicles.DeleteVehicle;

public class DeleteVehicleCommandHandler : IDeleteVehicleCommandHandler
{
    private readonly IVehicleRepository _vehicleRepository;

    public DeleteVehicleCommandHandler(IVehicleRepository vehicleRepository)
    {
        _vehicleRepository = vehicleRepository;
    }
    public async Task HandleAsync(int id, CancellationToken cancellationToken)
    {
        var vehicle = await _vehicleRepository.GetById(id, cancellationToken);

        if (vehicle is null)
        {
            throw new Exception($"Vehicle with id {id} not found.");
        }

        await _vehicleRepository.DeleteAsync(vehicle, cancellationToken);
    }
}