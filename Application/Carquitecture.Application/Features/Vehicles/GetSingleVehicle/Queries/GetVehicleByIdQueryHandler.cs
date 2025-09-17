using Carquitecture.Application.Features.Vehicles.Models;
using Carquitecture.Application.Repositories;

namespace Carquitecture.Application.Features.Vehicles.GetSingleVehicle.Queries;

public class GetVehicleByIdQueryHandler : IGetVehicleByIdQueryHandler
{
    private readonly IUnitOfWork _unitOfWork;

    public GetVehicleByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        ArgumentNullException.ThrowIfNull(unitOfWork, nameof(unitOfWork));
        _unitOfWork = unitOfWork;
    }
    public async Task<VehicleDto?> HandleAsync(int id, CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.Vehicles.GetByIdAsync(id, cancellationToken);

        if (result is null)
        {
            return null;
        }

        return new VehicleDto(result.Id, result.LicensePlate, result.Owner);
    }
}