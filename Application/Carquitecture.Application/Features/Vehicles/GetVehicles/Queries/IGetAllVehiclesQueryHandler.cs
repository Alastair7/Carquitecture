using Carquitecture.Application.Features.Vehicles.Models;

namespace Carquitecture.Application.Features.Vehicles.GetVehicles.Queries;

public interface IGetAllVehiclesQueryHandler
{
    Task<IEnumerable<VehicleDto>> HandleAsync(CancellationToken cancellationToken);
}
