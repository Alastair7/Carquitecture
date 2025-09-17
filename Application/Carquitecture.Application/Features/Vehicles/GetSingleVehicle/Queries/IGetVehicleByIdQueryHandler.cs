using Carquitecture.Application.Features.Vehicles.Models;
using Carquitecture.Application.Shared.ErrorHandling;

namespace Carquitecture.Application.Features.Vehicles.GetSingleVehicle.Queries;

public interface IGetVehicleByIdQueryHandler
{
    Task<Result<VehicleDto?>> HandleAsync(int id, CancellationToken cancellationToken);
}
