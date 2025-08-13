using Carquitecture.Application.Repositories;
using Carquitecture.Domain;
using Carquitecture.Infrastructure.Data;

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
        _context.Vehicles.Add(vehicle);
        await _context.SaveChangesAsync(cancellationToken);

        return vehicle.Id;
    }
}