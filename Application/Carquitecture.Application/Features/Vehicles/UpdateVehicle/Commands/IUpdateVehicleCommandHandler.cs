using Carquitecture.Application.Features.Vehicles.Models;

namespace Carquitecture.Application.Features.Vehicles.UpdateVehicle.Commands;

public interface IUpdateVehicleCommandHandler
{
    Task<VehicleDto> HandleAsync(UpdateVehicleCommand command, CancellationToken cancellationToken);
}
