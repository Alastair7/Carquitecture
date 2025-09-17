using Carquitecture.Application.Features.Vehicles.Models;
using Carquitecture.Application.Repositories;
using Carquitecture.Application.Shared.ErrorHandling;

namespace Carquitecture.Application.Features.Vehicles.GetVehicles.Queries;

public record GetAllVehiclesQueryHandler : IGetAllVehiclesQueryHandler
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllVehiclesQueryHandler(IUnitOfWork unitOfWork)
    {
        ArgumentNullException.ThrowIfNull(unitOfWork, nameof(unitOfWork));
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<IEnumerable<VehicleDto>>> HandleAsync(CancellationToken cancellationToken)
    {
        var vehicles = await _unitOfWork.Vehicles.GetAllAsync(cancellationToken);

        return Result<IEnumerable<VehicleDto>>
            .Success(vehicles.Select(v => new VehicleDto(v.Id, v.LicensePlate, v.Owner)));
    }
}