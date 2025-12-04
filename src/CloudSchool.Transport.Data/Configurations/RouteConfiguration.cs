using CloudSchool.Transport.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CloudSchool.Transport.Data.Configurations
{
    public class RouteConfiguration : IEntityTypeConfiguration<Route>
    {
        public void Configure(EntityTypeBuilder<Route> builder)
        {
            // Route Configuration
            builder
                .Entity<Route>()
                .HasMany(r => r.Stations)
                .WithOne(s => s.Route)
                .HasForeignKey(s => s.RouteId);
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .Entity<Route>()
                .HasMany(r => r.Trips)
                .WithOne(t => t.Route)
                .HasForeignKey(t => t.RouteId);
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(r => r.Vehicle)
                .WithMany()
                .HasForeignKey(r => r.VehicleId);
                .OnDelete(DeleteBehavior.Restrict);
            
            builder
                .HasOne(r => r.Driver)
                .WithMany()
                .HasForeignKey(r => r.DriverId)
                .OnDelete(DeleteBehavior.Restrict);
            
            builder
                .HasOne(r => r.Minder)
                .WithMany()
                .HasForeignKey(r => r.MinderId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
