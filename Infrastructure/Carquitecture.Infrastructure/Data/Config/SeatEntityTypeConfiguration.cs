using Carquitecture.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Carquitecture.Infrastructure.Data.Config;

internal class SeatEntityTypeConfiguration : IEntityTypeConfiguration<Seat>
{
    public void Configure(EntityTypeBuilder<Seat> builder)
    {
        builder.ToTable("Seat")
            .HasOne(s => s.Vehicle)
            .WithMany(v => v.Seats)
            .HasForeignKey(s => s.VehicleId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
