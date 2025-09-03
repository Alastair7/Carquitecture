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
        // TODO: Investigate about how to run de migration to create the DB in Postgres.

        // TODO: Use specific model builder class (not defined in this class). Investigate.
        new VehicleEntityTypeConfiguration().Configure(modelBuilder.Entity<Vehicle>());
    }
}