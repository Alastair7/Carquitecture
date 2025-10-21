
using Carquitecture.Application.Repositories;
using Carquitecture.Application.Shared.ErrorHandling;
using Carquitecture.Domain;
using DispatchR.Abstractions.Send;

namespace Carquitecture.Application.Features.Vehicles.CreateVehicle.Commands;

public class CreateVehicleCommandHandler : IRequestHandler<CreateVehicleCommand, Task<Result>>
{
    private readonly IVehicleRepository _vehicleRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateVehicleCommandHandler(IVehicleRepository vehicleRepository, IUnitOfWork unitOfWork)
    {
        ArgumentNullException.ThrowIfNull(vehicleRepository, nameof(vehicleRepository));
        _vehicleRepository = vehicleRepository;

        ArgumentNullException.ThrowIfNull(unitOfWork, nameof(unitOfWork));
        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(CreateVehicleCommand request, CancellationToken cancellationToken)
    {
        var seats = request.Seats.Select(s => new Seat(s.Material, s.Color)).ToList();
        var owners = request.Owners.Select(o => new Owner(o.Name, o.Surname, o.Active)).ToList();

        var vehicle = new Vehicle(request.LicensePlate, request.Type, owners, seats);

        await _vehicleRepository.AddAsync(vehicle, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
