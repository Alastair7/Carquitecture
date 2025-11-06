using Carquitecture.Application.Features.Vehicles.Models;
using Carquitecture.Application.Shared.Abstractions;
using DispatchR.Abstractions.Send;

namespace Carquitecture.Application.Features.Vehicles.GetVehicles.Queries;

public record GetAllVehiclesQuery : IQuery<GetAllVehiclesQuery, IEnumerable<VehicleDto>>
 { }
