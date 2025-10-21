using Carquitecture.Application.Features.Vehicles.Models;
using Carquitecture.Application.Repositories;
using DispatchR.Abstractions.Send;

namespace Carquitecture.Application.Features.Vehicles.GetSingleVehicle.Queries;

public class GetVehicleByIdQueryHandler : IRequestHandler<GetVehicleByIdQuery, Task<VehicleDto?>>
{
    private readonly IVehicleRepository _vehicleRepository;

    public GetVehicleByIdQueryHandler(IVehicleRepository vehicleRepository)
    {
        ArgumentNullException.ThrowIfNull(vehicleRepository, nameof(vehicleRepository));
        _vehicleRepository = vehicleRepository;
    }

    public async Task<VehicleDto?> Handle(GetVehicleByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _vehicleRepository.GetByIdAsync(request.Id, cancellationToken);

        var seats = result?.Seats
            .Select(s => new SeatDto(s.Id, s.Material, s.Color)) ?? [];

        var owners = result?.Owners
            .Select(o => new OwnerDto(o.Id, o.Name, o.Surname, o.Active)) ?? [];

        return result is null
            ? default
            : new VehicleDto(result.Id, result.LicensePlate, owners, seats);
    }
}