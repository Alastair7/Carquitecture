using Carquitecture.Application.Features.Vehicles.Models;

namespace Carquitecture.API.Controllers.Vehicle.Requests;

public class UpdateVehicleRequest
{
    public required LicensePlateDto LicensePlate { get; set; }

    public required string Type { get; set; }

    public required IEnumerable<OwnerDto> Owners { get; set; }

    public IEnumerable<SeatDto> Seats { get; set; } = [];
}