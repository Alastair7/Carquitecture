using Carquitecture.Application.Shared.ErrorHandling;

namespace Carquitecture.Application.Features.Vehicles.DeleteVehicle;

public interface IDeleteVehicleCommandHandler
{
    Task<BaseResult> HandleAsync(int id, CancellationToken cancellationToken);
}
