using Carquitecture.API.Controllers.Vehicle.Requests;
using Carquitecture.Application.Features.Vehicles.CreateVehicle.Commands;
using Carquitecture.Application.Features.Vehicles.DeleteVehicle;
using Carquitecture.Application.Features.Vehicles.GetSingleVehicle.Queries;
using Carquitecture.Application.Features.Vehicles.GetVehicles.Queries;
using Carquitecture.Application.Features.Vehicles.UpdateVehicle.Commands;
using Microsoft.AspNetCore.Mvc;

namespace Carquitecture.API.Controllers.Vehicle;

[ApiController]
[Route("api/[controller]")]
public class VehicleController : ControllerBase
{

    private readonly ICreateVehicleCommandHandler _createVehicleHandler;
    private readonly IGetAllVehiclesQueryHandler _getAllVehiclesHandler;
    private readonly IGetVehicleByIdQueryHandler _getVehicleByIdHandler;
    private readonly IUpdateVehicleCommandHandler _updateVehicleHandler;
    private readonly IDeleteVehicleCommandHandler _deleteVehicleHandler;

    public VehicleController(ICreateVehicleCommandHandler createVehicleHandler,
        IGetAllVehiclesQueryHandler getAllVehiclesHandler,
        IGetVehicleByIdQueryHandler getVehicleByIdHandler,
        IUpdateVehicleCommandHandler updateVehicleHandler,
        IDeleteVehicleCommandHandler deleteVehicleHandler
        )
    {
        ArgumentNullException.ThrowIfNull(createVehicleHandler, nameof(createVehicleHandler));
        _createVehicleHandler = createVehicleHandler;

        ArgumentNullException.ThrowIfNull(getAllVehiclesHandler, nameof(getAllVehiclesHandler));
        _getAllVehiclesHandler = getAllVehiclesHandler;

        ArgumentNullException.ThrowIfNull(getVehicleByIdHandler, nameof(getVehicleByIdHandler));
        _getVehicleByIdHandler = getVehicleByIdHandler;

        ArgumentNullException.ThrowIfNull(updateVehicleHandler, nameof(updateVehicleHandler));
        _updateVehicleHandler = updateVehicleHandler;

        ArgumentNullException.ThrowIfNull(deleteVehicleHandler, nameof(deleteVehicleHandler));
        _deleteVehicleHandler = deleteVehicleHandler;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateVehicleRequest request, CancellationToken cancellationToken)
    {
        var command = new CreateVehicleCommand()
        {
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

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        var result = await _getVehicleByIdHandler.HandleAsync(id, cancellationToken);

        return result is null ? NotFound(id) : Ok(result);
    }

    // Add ID to route.
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateVehicleRequest request, CancellationToken cancellationToken)
    {
        var command = new UpdateVehicleCommand()
        {
            Id = request.Id,
            LicensePlate = request.LicensePlate,
            Type = request.Type,
            Owner = request.Owner
        };

        var result = await _updateVehicleHandler.HandleAsync(command, cancellationToken);

        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        await _deleteVehicleHandler.HandleAsync(id, cancellationToken);

        return NoContent();
    }
}