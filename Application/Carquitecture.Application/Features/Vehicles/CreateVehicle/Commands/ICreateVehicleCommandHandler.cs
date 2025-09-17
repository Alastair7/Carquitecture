namespace Carquitecture.Application.Features.Vehicles.CreateVehicle.Commands;

public interface ICreateVehicleCommandHandler
{
    Task HandleAsync(CreateVehicleCommand command, CancellationToken cancellationToken);
}
