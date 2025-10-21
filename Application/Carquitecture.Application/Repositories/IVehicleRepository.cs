using Carquitecture.Domain;

namespace Carquitecture.Application.Repositories;

public interface IVehicleRepository : IGenericRepository<Vehicle>
{
    Task<IEnumerable<Vehicle>> GetVehicleWithRelationships();
}