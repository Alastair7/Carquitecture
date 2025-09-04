namespace Carquitecture.Application.Features.Vehicles.DeleteVehicle;

public interface IDeleteVehicleCommandHandler
{
    Task HandleAsync(int id, CancellationToken cancellationToken);
}
