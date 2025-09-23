namespace Carquitecture.Application.Features.Vehicles.Models;

public record VehicleDto(int Id, string LicensePlate, string Owner, IEnumerable<SeatDto> Seats);
