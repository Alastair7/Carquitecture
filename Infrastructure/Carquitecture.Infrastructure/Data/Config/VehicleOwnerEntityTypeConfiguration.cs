using Carquitecture.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Carquitecture.Infrastructure.Data.Config;

internal class VehicleOwnerEntityTypeConfiguration : IEntityTypeConfiguration<VehicleOwner>
{
    public void Configure(EntityTypeBuilder<VehicleOwner> builder)
    {
        builder.ToTable("VehicleOwners");

        builder.HasKey(vo => new { vo.VehicleId, vo.OwnerId });
    }
}
