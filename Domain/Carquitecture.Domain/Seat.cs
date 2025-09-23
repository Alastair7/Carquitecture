namespace Carquitecture.Domain;

public class Seat
{
    public Seat(string material, string color)
    {
        Material = material;
        Color = color;
    }

    public int Id { get; set; }

    public string Material { get; set; } = string.Empty;

    public string Color { get; set; } = string.Empty;

    public int VehicleId { get; set; }

    public Vehicle Vehicle { get; set; } = null!;
}
