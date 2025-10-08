using Carquitecture.Application.Features.Vehicles.Models;
using DispatchR.Abstractions.Send;

namespace Carquitecture.Application.Features.Vehicles.GetSingleVehicle.Queries;

public record GetVehicleByIdQuery(int Id) : IRequest<GetVehicleByIdQuery, Task<VehicleDto?>>;