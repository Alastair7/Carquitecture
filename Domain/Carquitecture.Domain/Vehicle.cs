namespace Carquitecture.Domain;

public class Vehicle
{
    public Vehicle(string licensePlate, string type, string owner) {
        LicensePlate = licensePlate;
        Type = type;
        Owner = owner;
    }

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

    public void SetLicensePlate(string licensePlate)
    {
        LicensePlate = licensePlate;
    }

    public void SetType(string type)
    {
        Type = type;
    }

    public void SetOwner(string owner)
    {
        Owner = owner;
    }
}