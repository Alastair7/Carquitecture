
using Carquitecture.Application.Features.Vehicles.Models;
using Carquitecture.Application.Repositories;
using Carquitecture.Application.Shared.ErrorHandling;
using DispatchR.Abstractions.Send;

namespace Carquitecture.Application.Features.Vehicles.UpdateVehicle.Commands;

public class UpdateVehicleCommandHandler : IRequestHandler<UpdateVehicleCommand, Task<Result<VehicleDto>>>
{
    private readonly IVehicleRepository _vehicleRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateVehicleCommandHandler(IVehicleRepository vehicleRepository, IUnitOfWork unitOfWork)
    {
        ArgumentNullException.ThrowIfNull(vehicleRepository, nameof(vehicleRepository));
        _vehicleRepository = vehicleRepository;

        ArgumentNullException.ThrowIfNull(unitOfWork, nameof(unitOfWork));
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<VehicleDto>> Handle(UpdateVehicleCommand request, CancellationToken cancellationToken)
    {
        var vehicle = await _vehicleRepository.GetByIdAsync(request.Id, cancellationToken);

        if (vehicle is null)
        {
            return Result<VehicleDto>.Failure(new Error("VehicleNotFound", $"Vehicle with id {request.Id} not found."));
        }

        vehicle.SetLicensePlate(request.LicensePlate);
        vehicle.SetOwner(request.Owner);
        vehicle.SetType(request.Type);
        vehicle.AddSeats(request.Seats);

        _vehicleRepository.Update(vehicle);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var seats = vehicle.Seats
            .Select(s => new SeatDto(s.Id, s.Material, s.Color));

        return Result<VehicleDto>.Success(new VehicleDto(vehicle.Id, vehicle.LicensePlate, vehicle.Owner, seats));
    }
}