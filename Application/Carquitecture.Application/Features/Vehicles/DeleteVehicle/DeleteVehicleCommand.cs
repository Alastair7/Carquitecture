using Carquitecture.Application.Shared.Abstractions;
using Carquitecture.Application.Shared.ErrorHandling;
using DispatchR.Abstractions.Send;

namespace Carquitecture.Application.Features.Vehicles.DeleteVehicle;

public record DeleteVehicleCommand(int Id) : ICommand<DeleteVehicleCommand, Result>;