
using Carquitecture.Application.Repositories;
using Carquitecture.Application.Shared.ErrorHandling;

namespace Carquitecture.Application.Features.Vehicles.DeleteVehicle;

public class DeleteVehicleCommandHandler : IDeleteVehicleCommandHandler
{
    private readonly IVehicleRepository _vehicleRepository;

    public DeleteVehicleCommandHandler(IVehicleRepository vehicleRepository)
    {
        _vehicleRepository = vehicleRepository;
    }
    public async Task<Result> HandleAsync(int id, CancellationToken cancellationToken)
    {
        var vehicle = await _vehicleRepository.GetByIdAsync(id, cancellationToken);

        if (vehicle is null)
        {
            return Result.Failure(new Error("VehicleNotFound", $"Vehicle with id {id} not found."));
        }

         _vehicleRepository.Delete(vehicle);

        return Result.Success();
    }
}