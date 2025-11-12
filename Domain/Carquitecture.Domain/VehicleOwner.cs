namespace Carquitecture.Domain;

public class VehicleOwner
{
    public int VehicleId { get; set; }
    public Vehicle Vehicle { get; set; } = null!;

    public int OwnerId { get; set; }
    public Owner Owner { get; set; } = null!;

    public bool IsOwnerActive { get; set; }
}
