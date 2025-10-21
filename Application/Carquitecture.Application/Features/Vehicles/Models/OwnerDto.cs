namespace Carquitecture.Application.Features.Vehicles.Models;

public record OwnerDto(int Id, string Name, string Surname, bool Active);

public record CreateOwnerDto(string Name, string Surname, bool Active);
