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
        await _context.Vehicles.AddAsync(vehicle);
        await _context.SaveChangesAsync(cancellationToken);

        return vehicle.Id;
    }

    public async Task<IEnumerable<Vehicle>> GetAllAsync(CancellationToken cancellationToken)
    {
        // TODO: Investigate about as not tracking.
        // TODO: Test Update with as not tracking.
        var vehicles = await _context.Vehicles.ToListAsync(cancellationToken);

        return vehicles;
    }
}