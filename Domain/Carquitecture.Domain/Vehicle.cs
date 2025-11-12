using Carquitecture.Domain.Abstractions;

namespace Carquitecture.Domain;

public sealed class LicensePlate : ValueObject
{
    public string PlateNumber { get; init; } = string.Empty;
    public string Country { get; init; } = string.Empty;

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return PlateNumber;
        yield return Country;
    }
}

public class Vehicle : IAggregateRoot
{
    private readonly List<Owner> _owners = [];
    private readonly List<Seat> _seats = [];

    private Vehicle() { }

    public Vehicle(LicensePlate licensePlate, string type) {
        LicensePlate = licensePlate;
        Type = type;
    }

    public Vehicle(int id, LicensePlate licensePlate, string type)
    {
        Id = id;
        LicensePlate = licensePlate;
        Type = type;
    }

    public int Id { get; private set; }

    public LicensePlate LicensePlate { get; private set; }

    public string Type { get; private set; } = string.Empty;

    public ICollection<VehicleOwner> VehicleOwners { get; private set; } = [];

    public IReadOnlyCollection<Owner> Owners => _owners.AsReadOnly();
    public IReadOnlyCollection<Seat> Seats => _seats.AsReadOnly();


    public void SetLicensePlate(LicensePlate licensePlate)
    {
        LicensePlate = licensePlate;
    }

    public void SetType(string type)
    {
        Type = type;
    }

    public void AddOwner(Owner owner)
    {
        _owners.Add(owner);
    }

    public void ClearThenAddOwners(IEnumerable<Owner> owners)
    {
        _owners.Clear();

        foreach (var owner in owners)
        {
            _owners.Add(owner);
        }
    }

    public void AddSeat(Seat seat)
    {
        _seats.Add(seat);
    }

    public void ClearThenAddSeats(IEnumerable<Seat> seats)
    {
        _seats.Clear();

        foreach (var seat in seats)
        {
            _seats.Add(seat);
        }
    }
}