namespace Carquitecture.Infrastructure.Models;

public class Vehicle
{
    public int ID { get; set; }
    public string LicensePlate { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public string Owner { get; set; } = string.Empty;
}