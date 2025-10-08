using Carquitecture.Application.Shared.ErrorHandling;
using DispatchR.Abstractions.Send;

namespace Carquitecture.Application.Features.Vehicles.DeleteVehicle;

public record DeleteVehicleCommand(int Id) : IRequest<DeleteVehicleCommand, Task<Result>>;