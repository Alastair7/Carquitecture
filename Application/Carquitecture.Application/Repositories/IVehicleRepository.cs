using Carquitecture.Domain;

namespace Carquitecture.Application.Repositories;

public interface IVehicleRepository
{
   Task<int> CreateAsync(Vehicle vehicle, CancellationToken cancellationToken);
   Task<IEnumerable<Vehicle>> GetAllAsync(CancellationToken cancellationToken);
}