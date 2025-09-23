
using Carquitecture.Application.Repositories;
using Carquitecture.Application.Shared.ErrorHandling;
using Carquitecture.Domain;

namespace Carquitecture.Application.Features.Vehicles.CreateVehicle.Commands;

public class CreateVehicleCommandHandler : ICreateVehicleCommandHandler
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

    public async Task<Result> HandleAsync(CreateVehicleCommand command, CancellationToken cancellationToken)
    {
        var vehicle = new Vehicle(command.LicensePlate, command.Type, command.Owner, command.Seats);

        await _vehicleRepository.AddAsync(vehicle, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
