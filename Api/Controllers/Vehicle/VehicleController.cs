using Carquitecture.API.Controllers.Vehicle.Requests;
using Carquitecture.Application.Features.Vehicles.CreateVehicle.Commands;
using Microsoft.AspNetCore.Mvc;

namespace Carquitecture.API.Controllers.Vehicle;

[ApiController]
[Route("api/[controller]")]
public class VehicleController : ControllerBase
{
    // Mediator pattern solves this problem?
    private readonly ICreateVehicleCommandHandler _createVehicleHandler;

    public VehicleController(ICreateVehicleCommandHandler createVehicleHandler)
    {
        ArgumentNullException.ThrowIfNull(createVehicleHandler, nameof(createVehicleHandler));
        _createVehicleHandler = createVehicleHandler;
    }

    [HttpPost]
    public async  Task<IActionResult> Create([FromBody] CreateVehicleRequest request, CancellationToken cancellationToken)
    {
        var command = new CreateVehicleCommand() 
        {
            Id = request.Id,
            LicensePlate = request.LicensePlate,
            Type = request.Type,
            Owner = request.Owner
        };

        var id = await _createVehicleHandler.HandleAsync(command, cancellationToken);

        return Created($"/api/vehicle/{id}", id);
    }

    [HttpPut()]
    public IActionResult Update(int id, [FromBody] object vehicle)
    {
        // This method should handle the update of an existing vehicle.
        // For now, we will return a placeholder response.
        return Ok(new { Id = id, Message = "Vehicle updated" });
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        // This method should handle the deletion of a vehicle by its ID.
        // For now, we will return a placeholder response.
        return Ok(new { Id = id, Message = "Vehicle deleted" });
    }

    [HttpGet("{id}")]
    public IActionResult GetSingle(int id)
    {
        // This method should return a specific vehicle by its ID.
        // For now, we will return a placeholder response.
        return Ok(new { Id = id, Message = "Vehicle details" });
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        // This method should return a list of vehicles.
        // For now, we will return a placeholder response.
        return Ok(new { Message = "List of vehicles" });
    }
}