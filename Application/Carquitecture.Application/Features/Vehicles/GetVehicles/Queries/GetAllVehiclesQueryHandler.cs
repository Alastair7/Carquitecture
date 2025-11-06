using Carquitecture.Application.Features.Vehicles.Models;
using Carquitecture.Application.Repositories;
using DispatchR.Abstractions.Send;

namespace Carquitecture.Application.Features.Vehicles.GetVehicles.Queries;

public record GetAllVehiclesQueryHandler : IRequestHandler<GetAllVehiclesQuery, Task<IEnumerable<VehicleDto>>>
{
    private readonly IVehicleRepository _vehicleRepository;

    public GetAllVehiclesQueryHandler(IVehicleRepository vehicleRepository)
    {
        ArgumentNullException.ThrowIfNull(vehicleRepository, nameof(vehicleRepository));
        _vehicleRepository = vehicleRepository;
    }

    public async Task<IEnumerable<VehicleDto>> Handle(GetAllVehiclesQuery request, CancellationToken cancellationToken)
    {
        var vehicles = await _vehicleRepository.GetVehicleWithRelationships();

        return vehicles.Select(v => new VehicleDto(
                              v.Id,
                              new LicensePlateDto(v.LicensePlate.PlateNumber, v.LicensePlate.Country),
                              v.Owners.Select(o => new OwnerDto(o.Id, o.Name, o.Surname, o.Active)),
                              v.Seats.Select(s => new SeatDto(s.Id, s.Material, s.Color))
                              )
            );
    }
}