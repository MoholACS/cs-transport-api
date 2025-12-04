using CloudSchool.Transport.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CloudSchool.Transport.Data.Configurations
{
    public class TripConfiguration : IEntityTypeConfiguration<Trip>
    {
        public void Configure(EntityTypeBuilder<Trip> builder)
        {
            // Trip Configuration
            builder
                .Entity<Trip>()
                .HasOne(t => t.Vehicle)
                .WithMany()
                .HasForeignKey(t => t.VehicleId);

            builder
                .Entity<Trip>()
                .HasOne(t => t.Driver)
                .WithMany()
                .HasForeignKey(t => t.DriverId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Entity<Trip>()
                .HasOne(t => t.Minder)
                .WithMany()
                .HasForeignKey(t => t.MinderId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
