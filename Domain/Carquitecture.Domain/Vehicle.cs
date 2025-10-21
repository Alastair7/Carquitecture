namespace Carquitecture.Domain;

public class Vehicle
{
    private Vehicle() { }

    public Vehicle(string licensePlate, string type, ICollection<Owner> owners, IEnumerable<Seat> seats) {
        LicensePlate = licensePlate;
        Type = type;
        Owners = owners;
        Seats = [.. seats];
    }

    public Vehicle(int id, string licensePlate, string type, ICollection<Owner> owners)
    {
        Id = id;
        LicensePlate = licensePlate;
        Type = type;
        Owners = owners;
    }

    public int Id { get; private set; }

    public string LicensePlate { get; private set; } = string.Empty;

    public string Type { get; private set; } = string.Empty;

    public ICollection<Owner> Owners { get; } = [];

    public ICollection<Seat> Seats { get; set; } = [];

    public void SetLicensePlate(string licensePlate)
    {
        LicensePlate = licensePlate;
    }

    public void SetType(string type)
    {
        Type = type;
    }

    public void AddOwner(Owner owner)
    {
        Owners.Add(owner);
    }

    public void ClearThenAddOwners(IEnumerable<Owner> owners)
    {
        Owners.Clear();

        foreach (var owner in owners)
        {
            Owners.Add(owner);
        }
    }

    public void AddSeat(Seat seat)
    {
        Seats.Add(seat);
    }

    public void ClearThenAddSeats(IEnumerable<Seat> seats)
    {
        Seats.Clear();

        foreach (var seat in seats)
        {
            Seats.Add(seat);
        }
    }
}