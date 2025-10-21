using Carquitecture.API.Controllers.Vehicle.Requests;
using Carquitecture.Application.Features.Vehicles.CreateVehicle.Commands;
using Carquitecture.Application.Features.Vehicles.DeleteVehicle;
using Carquitecture.Application.Features.Vehicles.GetSingleVehicle.Queries;
using Carquitecture.Application.Features.Vehicles.GetVehicles.Queries;
using Carquitecture.Application.Features.Vehicles.UpdateVehicle.Commands;
using Carquitecture.Domain;
using DispatchR;
using Microsoft.AspNetCore.Mvc;

namespace Carquitecture.API.Controllers.Vehicle;

[ApiController]
[Route("api/[controller]")]
public class VehicleController : ControllerBase
{

    private readonly IMediator _mediator;

    public VehicleController(IMediator mediator)
    {
        ArgumentNullException.ThrowIfNull(mediator, nameof(mediator));
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateVehicleRequest request, CancellationToken cancellationToken)
    {
        var command = new CreateVehicleCommand()
        {
            LicensePlate = request.LicensePlate,
            Type = request.Type,
            Owners = [.. request.Owners.Select(o => new Owner(o.Name, o.Surname, o.Active))],
            Seats = request.Seats.Select(s => new Seat(s.Material, s.Color))
        };

         var result = await _mediator.Send(command, cancellationToken);

        return result.IsFailure ? BadRequest(result.Error) : Created();
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var query = new GetAllVehiclesQuery();
        var result = await _mediator.Send(query, cancellationToken);

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        var query = new GetVehicleByIdQuery(id);
        var result = await _mediator.Send(query, cancellationToken);

        return result is null ? NotFound() : Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateVehicleRequest request, CancellationToken cancellationToken)
    {
        var command = new UpdateVehicleCommand()
        {
            Id = id,
            LicensePlate = request.LicensePlate,
            Type = request.Type,
            Owners = request.Owners
        };

        var result = await _mediator.Send(command, cancellationToken);

        return result.IsFailure ? NotFound(result.Error) : Ok(result.Value);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        var command = new DeleteVehicleCommand(id);
        var result = await _mediator.Send(command, cancellationToken);

        return result.IsFailure ? NotFound(result.Error) : NoContent();
    }
}