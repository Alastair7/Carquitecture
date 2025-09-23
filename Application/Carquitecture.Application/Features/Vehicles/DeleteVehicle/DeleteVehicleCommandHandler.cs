
using Carquitecture.Application.Repositories;
using Carquitecture.Application.Shared.ErrorHandling;

namespace Carquitecture.Application.Features.Vehicles.DeleteVehicle;

public class DeleteVehicleCommandHandler : IDeleteVehicleCommandHandler
{
    private readonly IVehicleRepository _vehicleRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteVehicleCommandHandler(IVehicleRepository vehicleRepository, IUnitOfWork unitOfWork)
    {
        _vehicleRepository = vehicleRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<Result> HandleAsync(int id, CancellationToken cancellationToken)
    {
        var vehicle = await _vehicleRepository.GetByIdAsync(id, cancellationToken);

        if (vehicle is null)
        {
            return Result.Failure(new Error("VehicleNotFound", $"Vehicle with id {id} not found."));
        }

         _vehicleRepository.Delete(vehicle);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}