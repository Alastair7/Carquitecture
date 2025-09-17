
using Carquitecture.Application.Repositories;

namespace Carquitecture.Application.Features.Vehicles.DeleteVehicle;

public class DeleteVehicleCommandHandler : IDeleteVehicleCommandHandler
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteVehicleCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task HandleAsync(int id, CancellationToken cancellationToken)
    {
        var vehicle = await _unitOfWork.Vehicles.GetByIdAsync(id, cancellationToken);

        if (vehicle is null)
        {
            throw new Exception($"Vehicle with id {id} not found.");
        }

         _unitOfWork.Vehicles.Delete(vehicle);
        await _unitOfWork.SaveChangesAsync();
    }
}