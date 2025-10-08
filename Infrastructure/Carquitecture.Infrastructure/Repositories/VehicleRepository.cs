using Carquitecture.Application.Repositories;
using Carquitecture.Domain;
using Carquitecture.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Carquitecture.Infrastructure.Repositories;

public class VehicleRepository : GenericRepository<Vehicle>, IVehicleRepository
{

    public VehicleRepository(VehicleContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Vehicle>> GetVehicleWithSeats() 
    {
        return await _context.Set<Vehicle>().Include(v => v.Seats).ToListAsync();
    }
}