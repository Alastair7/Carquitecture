using Carquitecture.Application.Features.Vehicles.Models;
using DispatchR.Abstractions.Send;

namespace Carquitecture.Application.Features.Vehicles.GetVehicles.Queries;

public record GetAllVehiclesQuery : IRequest<GetAllVehiclesQuery, Task<IEnumerable<VehicleDto>>> 
 { }
