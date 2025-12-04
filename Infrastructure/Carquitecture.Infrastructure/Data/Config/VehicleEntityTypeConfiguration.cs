using Carquitecture.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Carquitecture.Infrastructure.Data.Config;

internal class VehicleEntityTypeConfiguration : IEntityTypeConfiguration<Vehicle>
{
    public void Configure(EntityTypeBuilder<Vehicle> builder)
    {
        // Create an entity about VehicleOwner many-to-many relationship
        builder.ToTable("Vehicle");

        builder.ComplexProperty(property => property.LicensePlate);

        //builder.HasMany(v => v.VehicleOwners)
        //    .WithOne(vo => vo.Vehicle)
        //    .HasForeignKey(vo => vo.VehicleId);
    }
}
