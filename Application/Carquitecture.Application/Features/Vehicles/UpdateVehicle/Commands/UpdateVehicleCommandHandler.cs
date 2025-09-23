
using Carquitecture.Application.Features.Vehicles.Models;
using Carquitecture.Application.Repositories;
using Carquitecture.Application.Shared.ErrorHandling;

namespace Carquitecture.Application.Features.Vehicles.UpdateVehicle.Commands;

public class UpdateVehicleCommandHandler : IUpdateVehicleCommandHandler
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
    public async Task<Result<VehicleDto>> HandleAsync(UpdateVehicleCommand command, CancellationToken cancellationToken)
    {
        var vehicle = await _vehicleRepository.GetByIdAsync(command.Id, cancellationToken);

        if (vehicle is null)
        { 
            return Result<VehicleDto>.Failure(new Error("VehicleNotFound", $"Vehicle with id {command.Id} not found."));
        }

        vehicle.SetLicensePlate(command.LicensePlate);
        vehicle.SetOwner(command.Owner);
        vehicle.SetType(command.Type);
        vehicle.AddSeats(command.Seats);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var seats = vehicle.Seats
            .Select(s => new SeatDto(s.Id, s.Material, s.Color));

        return Result<VehicleDto>.Success(new VehicleDto(vehicle.Id, vehicle.LicensePlate, vehicle.Owner, seats));
    }
}