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
        var result = await _vehicleRepository.GetByIdAsync(id, cancellationToken);

        var seats = result?.Seats
            .Select(s => new SeatDto(s.Id, s.Material, s.Color)) ?? [];

        return result is null 
            ? default 
            : new VehicleDto(result.Id, result.LicensePlate, result.Owner, seats);
    }
}