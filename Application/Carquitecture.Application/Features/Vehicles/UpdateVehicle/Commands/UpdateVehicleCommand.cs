using Carquitecture.Application.Features.Vehicles.Models;
using Carquitecture.Application.Shared.Abstractions;
using Carquitecture.Application.Shared.ErrorHandling;

namespace Carquitecture.Application.Features.Vehicles.UpdateVehicle.Commands;

public class UpdateVehicleCommand : ICommand<UpdateVehicleCommand, Result<VehicleDto>>
{
    public int Id { get; init; }
    public required LicensePlateDto LicensePlate { get; init; }
    public string Type { get; init; } = string.Empty;
    public IEnumerable<OwnerDto> Owners { get; init; } = [];
    public IEnumerable<SeatDto> Seats { get; init; } = [];
}