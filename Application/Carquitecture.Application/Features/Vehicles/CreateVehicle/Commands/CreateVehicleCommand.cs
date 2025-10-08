using Carquitecture.Application.Shared.ErrorHandling;
using Carquitecture.Domain;
using DispatchR.Abstractions.Send;

namespace Carquitecture.Application.Features.Vehicles.CreateVehicle.Commands;

public class CreateVehicleCommand : IRequest<CreateVehicleCommand,Task<Result>>
{
    public string LicensePlate { get; init; } = string.Empty;
    public string Type { get; init; } = string.Empty;
    public string Owner { get; init; } = string.Empty;

    // Command should communicate with DTO or with domain model?
    public IEnumerable<Seat> Seats { get; init; } = [];
}
