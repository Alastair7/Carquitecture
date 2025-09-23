using Carquitecture.Application.Features.Vehicles.Models;
using Carquitecture.Application.Repositories;
using Carquitecture.Application.Shared.ErrorHandling;

namespace Carquitecture.Application.Features.Vehicles.GetSingleVehicle.Queries;

public class GetVehicleByIdQueryHandler : IGetVehicleByIdQueryHandler
{
    private readonly IVehicleRepository _vehicleRepository;

    public GetVehicleByIdQueryHandler(IVehicleRepository vehicleRepository)
    {
        ArgumentNullException.ThrowIfNull(vehicleRepository, nameof(vehicleRepository));
        _vehicleRepository = vehicleRepository;
    }
    public async Task<Result<VehicleDto?>> HandleAsync(int id, CancellationToken cancellationToken)
    {
        var result = await _vehicleRepository.GetByIdAsync(id, cancellationToken);

        if (result is null)
        {
            return Result<VehicleDto?>.Failure(new Error("VehicleNotFound", "Vehicle not found"));
        }

        return Result<VehicleDto?>.Success(new VehicleDto(result.Id, result.LicensePlate, result.Owner));
    }
}