namespace Carquitecture.Application.Features.Vehicles.Models;
public record SeatDto(int Id, string Material, string Color);

public record CreateSeatDto(string Material, string Color);