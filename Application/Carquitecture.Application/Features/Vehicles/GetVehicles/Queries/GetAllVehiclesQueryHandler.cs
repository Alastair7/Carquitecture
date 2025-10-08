using Carquitecture.Application.Features.Vehicles.Models;
using Carquitecture.Application.Repositories;
using Carquitecture.Application.Shared.ErrorHandling;

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
        // Why do I get only one record instead of the whole list with the relationships?
        var vehicles = await _vehicleRepository.GetVehicleWithSeats();

        return vehicles.Select(v => new VehicleDto(
                              v.Id, 
                              v.LicensePlate, 
                              v.Owner, 
                              v.Seats.Select(s => new SeatDto(s.Id, s.Material, s.Color))
                              )
            );
    }
}