using Carquitecture.Domain;

namespace Carquitecture.Application.Repositories;

public interface IUnitOfWork : IDisposable
{
    IGenericRepository<Vehicle> Vehicles { get; }
    Task<int> SaveChangesAsync();
}
