using Carquitecture.Application.Features.Vehicles.Models;
using Carquitecture.Application.Repositories;

namespace Carquitecture.Application.Features.Vehicles.GetSingleVehicle.Queries;

public class GetVehicleByIdQueryHandler : IGetVehicleByIdQueryHandler
{
    private readonly IVehicleRepository _vehicleRepository;

    public GetVehicleByIdQueryHandler(IVehicleRepository vehicleRepository)
    {
        ArgumentNullException.ThrowIfNull(vehicleRepository, nameof(vehicleRepository));
        _vehicleRepository = vehicleRepository;
    }
    public async Task<VehicleDto?> HandleAsync(int id, CancellationToken cancellationToken)
    {
        var result = await _vehicleRepository.GetById(id, cancellationToken);

        if (result is null)
        {
            return null;
        }

        return new VehicleDto(result.Id, result.LicensePlate, result.Owner);
    }
}