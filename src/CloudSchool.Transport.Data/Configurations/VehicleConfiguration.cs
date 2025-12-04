using CloudSchool.Transport.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CloudSchool.Transport.Data.Configurations
{
    public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            // Vehicle Configuration
            builder.Entity<Vehicle>().HasMany(v => v.Routes).WithOne().HasForeignKey("VehicleId");
        }
    }
}
