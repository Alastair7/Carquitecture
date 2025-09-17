namespace Carquitecture.API.Controllers.Vehicle.Requests;

public class CreateVehicleRequest
{
    
    public required string LicensePlate { get; set; }
    
    public required string Type { get; set; }
    
    public required string Owner { get; set; }
}