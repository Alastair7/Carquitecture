namespace Carquitecture.Application.Features.Vehicles.Models;

public record VehicleDto(int Id, string LicensePlate, IEnumerable<OwnerDto> Owners, IEnumerable<SeatDto> Seats);
