using Carquitecture.Application.Features.Vehicles.Models;

namespace Carquitecture.Application.Features.Vehicles.GetSingleVehicle.Queries;

public interface IGetVehicleByIdQueryHandler
{
    Task<VehicleDto?> HandleAsync(int id, CancellationToken cancellationToken);
}
