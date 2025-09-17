using Carquitecture.Application.Features.Vehicles.Models;
using Carquitecture.Application.Shared.ErrorHandling;

namespace Carquitecture.Application.Features.Vehicles.GetVehicles.Queries;

public interface IGetAllVehiclesQueryHandler
{
    Task<Result<IEnumerable<VehicleDto>>> HandleAsync(CancellationToken cancellationToken);
}
