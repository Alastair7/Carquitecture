
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
        var vehicle = new Vehicle(request.LicensePlate, request.Type, request.Owner, request.Seats);

        await _vehicleRepository.AddAsync(vehicle, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }

    public async Task<Result> HandleAsync(CreateVehicleCommand command, CancellationToken cancellationToken)
    {
        var vehicle = new Vehicle(command.LicensePlate, command.Type, command.Owner, command.Seats);

        await _vehicleRepository.AddAsync(vehicle, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
