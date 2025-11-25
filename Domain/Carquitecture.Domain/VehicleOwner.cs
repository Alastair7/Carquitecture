namespace Carquitecture.Domain;

public class VehicleOwner
{
    public int VehicleId { get; set; }
    public required Vehicle Vehicle { get; set; }

    public int OwnerId { get; set; }
    public required Owner Owner { get; set; }

    public bool IsOwnerActive { get; set; }
}
