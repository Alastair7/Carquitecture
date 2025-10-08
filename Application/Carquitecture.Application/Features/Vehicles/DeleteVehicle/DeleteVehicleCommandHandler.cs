
using Carquitecture.Application.Repositories;
using Carquitecture.Application.Shared.ErrorHandling;
using DispatchR.Abstractions.Send;

namespace Carquitecture.Application.Features.Vehicles.DeleteVehicle;

public class DeleteVehicleCommandHandler : IRequestHandler<DeleteVehicleCommand, Task<Result>>
{
    private readonly IVehicleRepository _vehicleRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteVehicleCommandHandler(IVehicleRepository vehicleRepository, IUnitOfWork unitOfWork)
    {
        _vehicleRepository = vehicleRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(DeleteVehicleCommand request, CancellationToken cancellationToken)
    {
        var vehicle = await _vehicleRepository.GetByIdAsync(request.Id, cancellationToken);

        if (vehicle is null)
        {
            return Result.Failure(new Error("VehicleNotFound", $"Vehicle with id {request.Id} not found."));
        }

        _vehicleRepository.Delete(vehicle);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}