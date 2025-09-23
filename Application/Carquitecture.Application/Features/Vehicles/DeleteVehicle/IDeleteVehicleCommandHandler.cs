using Carquitecture.Application.Shared.ErrorHandling;

namespace Carquitecture.Application.Features.Vehicles.DeleteVehicle;

public interface IDeleteVehicleCommandHandler
{
    Task<Result> HandleAsync(int id, CancellationToken cancellationToken);
}
