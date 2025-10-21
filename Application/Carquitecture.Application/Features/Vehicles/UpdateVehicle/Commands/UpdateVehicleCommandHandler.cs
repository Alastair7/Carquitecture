
using Carquitecture.Application.Features.Vehicles.Models;
using Carquitecture.Application.Repositories;
using Carquitecture.Application.Shared.ErrorHandling;
using Carquitecture.Domain;
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

        var owners = request.Owners
            .Select(o => new Owner(o.Name, o.Surname, o.Active)).ToList();

        var seats = request.Seats
            .Select(s => new Seat(s.Material, s.Color)).ToList();

        vehicle.SetLicensePlate(request.LicensePlate);
        vehicle.ClearThenAddOwners(owners);
        vehicle.SetType(request.Type);
        vehicle.ClearThenAddSeats(seats);

        _vehicleRepository.Update(vehicle);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var seatsDto = vehicle.Seats
            .Select(s => new SeatDto(s.Id, s.Material, s.Color));

        var ownersDto = vehicle.Owners
            .Select(o => new OwnerDto(o.Id, o.Name, o.Surname, o.Active));

        return Result<VehicleDto>.Success(new VehicleDto(vehicle.Id, vehicle.LicensePlate, ownersDto, seatsDto));
    }
}