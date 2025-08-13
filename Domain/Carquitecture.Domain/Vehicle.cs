namespace Carquitecture.Domain;

public class Vehicle
{
    public Vehicle(int id, string licensePlate, string type, string owner)
    {
        Id = id;
        LicensePlate = licensePlate;
        Type = type;
        Owner = owner;
    }

    public int Id { get; private set; }

    public string LicensePlate { get; private set; } = string.Empty;

    public string Type { get; private set; } = string.Empty;

    public string Owner { get; private set; } = string.Empty;
}