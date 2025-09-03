using Carquitecture.API.Controllers.Vehicle.Requests;
using Carquitecture.Application.Features.Vehicles.CreateVehicle.Commands;
using Carquitecture.Application.Features.Vehicles.GetVehicles.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Carquitecture.API.Controllers.Vehicle;

[ApiController]
[Route("api/[controller]")]
public class VehicleController : ControllerBase
{

    private readonly ICreateVehicleCommandHandler _createVehicleHandler;
    private readonly IGetAllVehiclesQueryHandler _getAllVehiclesHandler;

    public VehicleController(ICreateVehicleCommandHandler createVehicleHandler, IGetAllVehiclesQueryHandler getAllVehiclesHandler)
    {
        ArgumentNullException.ThrowIfNull(createVehicleHandler, nameof(createVehicleHandler));
        _createVehicleHandler = createVehicleHandler;

        ArgumentNullException.ThrowIfNull(getAllVehiclesHandler, nameof(getAllVehiclesHandler));
        _getAllVehiclesHandler = getAllVehiclesHandler;
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

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var result = await _getAllVehiclesHandler.HandleAsync(cancellationToken);

        return Ok(result);
    }
}