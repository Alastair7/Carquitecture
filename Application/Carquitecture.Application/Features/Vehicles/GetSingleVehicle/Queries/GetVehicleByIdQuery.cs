using Carquitecture.Application.Features.Vehicles.Models;
using Carquitecture.Application.Shared.Abstractions;
using DispatchR.Abstractions.Send;

namespace Carquitecture.Application.Features.Vehicles.GetSingleVehicle.Queries;

public record GetVehicleByIdQuery(int Id) : IQuery<GetVehicleByIdQuery, VehicleDto?>;
