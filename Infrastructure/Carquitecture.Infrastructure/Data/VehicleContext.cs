﻿using Carquitecture.Domain;
using Carquitecture.Infrastructure.Data.Config;
using Microsoft.EntityFrameworkCore;

namespace Carquitecture.Infrastructure.Data;

// DbContext already implements SaveChangesAsync which is required for the UnitOfWork interface.
public class VehicleContext : DbContext
{
    public VehicleContext(DbContextOptions<VehicleContext> options) : base(options) 
    {
    }

    public DbSet<Vehicle> Vehicles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        new VehicleEntityTypeConfiguration().Configure(modelBuilder.Entity<Vehicle>());
    }
}