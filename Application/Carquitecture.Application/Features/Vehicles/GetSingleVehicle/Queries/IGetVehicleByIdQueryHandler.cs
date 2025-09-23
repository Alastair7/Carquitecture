using Carquitecture.Application.Features.Vehicles.Models;
using Carquitecture.Application.Shared.ErrorHandling;

namespace Carquitecture.Application.Features.Vehicles.GetSingleVehicle.Queries;

public interface IGetVehicleByIdQueryHandler
{
    // Result should not be used for queries operations.
    Task<Result<VehicleDto?>> HandleAsync(int id, CancellationToken cancellationToken);
}
