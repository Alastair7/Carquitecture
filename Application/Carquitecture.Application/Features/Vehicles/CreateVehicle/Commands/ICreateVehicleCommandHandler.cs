﻿using Carquitecture.Application.Shared.ErrorHandling;

namespace Carquitecture.Application.Features.Vehicles.CreateVehicle.Commands;

public interface ICreateVehicleCommandHandler
{
    Task<Result> HandleAsync(CreateVehicleCommand command, CancellationToken cancellationToken);
}
