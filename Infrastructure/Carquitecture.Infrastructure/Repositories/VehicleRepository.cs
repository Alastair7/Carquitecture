﻿using Carquitecture.Application.Repositories;
using Carquitecture.Domain;
using Carquitecture.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Carquitecture.Infrastructure.Repositories;

public class VehicleRepository : GenericRepository<Vehicle>, IVehicleRepository
{

    public VehicleRepository(VehicleContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Vehicle>> GetVehicleWithRelationships() 
    {
        return await _context.Set<Vehicle>()
            .AsNoTracking()
            .Include(v => v.Seats)
            .Include(v => v.Owners)
            .ToListAsync();
    }
}