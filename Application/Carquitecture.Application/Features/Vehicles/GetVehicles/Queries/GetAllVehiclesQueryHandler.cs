using Carquitecture.Application.Features.Vehicles.Models;
using Carquitecture.Application.Repositories;

namespace Carquitecture.Application.Features.Vehicles.GetVehicles.Queries;

public record GetAllVehiclesQueryHandler : IGetAllVehiclesQueryHandler
{
    private readonly IVehicleRepository _vehicleRepository;

    public GetAllVehiclesQueryHandler(IVehicleRepository vehicleRepository)
    {
        ArgumentNullException.ThrowIfNull(vehicleRepository, nameof(vehicleRepository));
        _vehicleRepository = vehicleRepository;
    }

    public async Task<IEnumerable<VehicleDto>> HandleAsync(CancellationToken cancellationToken)
    {
        var vehicles = await _vehicleRepository.GetAllAsync(cancellationToken);

        return vehicles.Select(v => new VehicleDto(v.Id, v.LicensePlate, v.Owner));
    }
}