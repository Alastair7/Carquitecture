using Carquitecture.Application.Repositories;
using Carquitecture.Domain;
using Carquitecture.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Carquitecture.Infrastructure.Repositories;

public class VehicleRepository : IVehicleRepository
{
    private readonly VehicleContext _context;

    public VehicleRepository(VehicleContext context)
    {
        _context = context;
    }

    public async Task<int> CreateAsync(Vehicle vehicle, CancellationToken cancellationToken)
    {  
        await _context.Vehicles.AddAsync(vehicle, cancellationToken);

        return vehicle.Id;
    }

    public async Task DeleteAsync(Vehicle vehicle, CancellationToken cancellationToken)
    {
         _context.Remove(vehicle);
    }

    public async Task<IEnumerable<Vehicle>> GetAllAsync(CancellationToken cancellationToken)
    {
        // TODO: Investigate about as not tracking.
        // TODO: Test Update with as not tracking.
        var vehicles = await _context.Vehicles.ToListAsync(cancellationToken);

        return vehicles;
    }

    public async Task<Vehicle?> GetById(int id, CancellationToken cancellationToken)
    {
        var vehicle = await _context.Vehicles.FirstOrDefaultAsync(v => v.Id == id, cancellationToken);
        
        return vehicle;
    }

    public async Task UpdateAsync(Vehicle vehicle, CancellationToken cancellationToken)
    {
        // Search alternatives to update entity
        _context.Vehicles.Update(vehicle);
    }
}