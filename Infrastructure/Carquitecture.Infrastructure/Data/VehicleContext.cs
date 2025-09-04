using Carquitecture.Domain;
using Carquitecture.Infrastructure.Data.Config;
using Microsoft.EntityFrameworkCore;

namespace Carquitecture.Infrastructure.Data;

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