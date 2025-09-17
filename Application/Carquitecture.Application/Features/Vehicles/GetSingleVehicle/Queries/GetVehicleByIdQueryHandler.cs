using Carquitecture.Application.Features.Vehicles.Models;
using Carquitecture.Application.Repositories;
using Carquitecture.Application.Shared.ErrorHandling;

namespace Carquitecture.Application.Features.Vehicles.GetSingleVehicle.Queries;

public class GetVehicleByIdQueryHandler : IGetVehicleByIdQueryHandler
{
    private readonly IUnitOfWork _unitOfWork;

    public GetVehicleByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        ArgumentNullException.ThrowIfNull(unitOfWork, nameof(unitOfWork));
        _unitOfWork = unitOfWork;
    }
    public async Task<Result<VehicleDto?>> HandleAsync(int id, CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.Vehicles.GetByIdAsync(id, cancellationToken);

        if (result is null)
        {
            return Result<VehicleDto?>.Failure(new Error("VehicleNotFound", "Vehicle not found"));
        }

        return Result<VehicleDto?>.Success(new VehicleDto(result.Id, result.LicensePlate, result.Owner));
    }
}