using Carquitecture.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Carquitecture.Infrastructure.Data.Config;

internal class OwnerEntityTypeConfiguration : IEntityTypeConfiguration<Owner>
{
    public void Configure(EntityTypeBuilder<Owner> builder)
    {
        builder.ToTable("Owners");

        builder.HasMany(v => v.VehicleOwners)
            .WithOne(vo => vo.Owner)
            .HasForeignKey(vo => vo.OwnerId);
    }
}
