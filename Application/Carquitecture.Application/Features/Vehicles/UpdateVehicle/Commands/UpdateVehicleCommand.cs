using Carquitecture.Application.Features.Vehicles.Models;
using Carquitecture.Application.Shared.ErrorHandling;
using Carquitecture.Domain;
using DispatchR.Abstractions.Send;

namespace Carquitecture.Application.Features.Vehicles.UpdateVehicle.Commands;

public class UpdateVehicleCommand : IRequest<UpdateVehicleCommand, Task<Result<VehicleDto>>>
{
    public int Id { get; init; }
    public string LicensePlate { get; init; } = string.Empty;
    public string Type { get; init; } = string.Empty;
    public string Owner { get; init; } = string.Empty;
    public IEnumerable<Seat> Seats { get; init; } = [];
}