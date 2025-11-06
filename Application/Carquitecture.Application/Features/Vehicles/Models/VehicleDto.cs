namespace Carquitecture.Application.Features.Vehicles.Models;

public record VehicleDto(int Id, LicensePlateDto LicensePlate, IEnumerable<OwnerDto> Owners, IEnumerable<SeatDto> Seats);
