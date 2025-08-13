namespace Carquitecture.Application.Features.Vehicles.CreateVehicle.Commands;

public interface ICreateVehicleCommandHandler
{
    Task<int> HandleAsync(CreateVehicleCommand command, CancellationToken cancellationToken);
}
