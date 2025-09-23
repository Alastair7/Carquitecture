
using Carquitecture.Application.Repositories;
using Carquitecture.Application.Shared.ErrorHandling;

namespace Carquitecture.Application.Features.Vehicles.DeleteVehicle;

public class DeleteVehicleCommandHandler : IDeleteVehicleCommandHandler
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteVehicleCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<Result> HandleAsync(int id, CancellationToken cancellationToken)
    {
        var vehicle = await _unitOfWork.Vehicles.GetByIdAsync(id, cancellationToken);

        if (vehicle is null)
        {
            return Result.Failure(new Error("VehicleNotFound", $"Vehicle with id {id} not found."));
        }

         _unitOfWork.Vehicles.Delete(vehicle);
        await _unitOfWork.SaveChangesAsync();

        return Result.Success();
    }
}