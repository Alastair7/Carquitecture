using Carquitecture.Application.Features.Vehicles.Models;
using Carquitecture.Application.Shared.Abstractions;
using Carquitecture.Application.Shared.ErrorHandling;
using Carquitecture.Domain;

namespace Carquitecture.Application.Features.Vehicles.CreateVehicle.Commands;

public class CreateVehicleCommand : ICommand<CreateVehicleCommand,Result>
{
    public required LicensePlateDto LicensePlate { get; init; }
    public string Type { get; init; } = string.Empty;
    public ICollection<Owner> Owners { get; init; } = [];
    public IEnumerable<Seat> Seats { get; init; } = [];
}
