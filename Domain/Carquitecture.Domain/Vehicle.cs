namespace Carquitecture.Domain;

public class Vehicle
{
    public Vehicle(string licensePlate, string type, string owner, IEnumerable<Seat> seats) {
        LicensePlate = licensePlate;
        Type = type;
        Owner = owner;
        Seats = [.. seats];
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

    public ICollection<Seat> Seats { get; set; } = [];

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

    public void AddSeat(Seat seat)
    {
        Seats.Add(seat);
    }

    public void AddSeats(IEnumerable<Seat> seats)
    {
        foreach (var seat in seats)
        {
            Seats.Add(seat);
        }
    }
}