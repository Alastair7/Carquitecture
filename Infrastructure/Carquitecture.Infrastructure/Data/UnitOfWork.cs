using Carquitecture.Application.Repositories;
using Carquitecture.Domain;
using Carquitecture.Infrastructure.Repositories;

namespace Carquitecture.Infrastructure.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly VehicleContext _context;
    public IGenericRepository<Vehicle> Vehicles {get;}

    public UnitOfWork(VehicleContext context)
    {
        _context = context;
        Vehicles = new GenericRepository<Vehicle>(context);
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}