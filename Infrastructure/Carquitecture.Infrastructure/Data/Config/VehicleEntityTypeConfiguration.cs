using Carquitecture.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Carquitecture.Infrastructure.Data.Config;

internal class VehicleEntityTypeConfiguration : IEntityTypeConfiguration<Vehicle>
{
    public void Configure(EntityTypeBuilder<Vehicle> builder)
    {
        // Create child entities by adding relationships 1 to many, many to many.
        // Check DI to inject all of the IEntityTypeConfiguration implementations.
        builder.ToTable("Vehicle")
            .HasMany(v => v.Owners)
            .WithMany(o => o.Vehicles)
            .UsingEntity(vo => vo.ToTable("VehicleOwner"));
    }
}
