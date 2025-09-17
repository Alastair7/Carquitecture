namespace Carquitecture.Application.Features.Vehicles.CreateVehicle.Commands;

public class CreateVehicleCommand
{
    public string LicensePlate { get; init; } = string.Empty;
    public string Type { get; init; } = string.Empty;
    public string Owner { get; init; } = string.Empty;
}
