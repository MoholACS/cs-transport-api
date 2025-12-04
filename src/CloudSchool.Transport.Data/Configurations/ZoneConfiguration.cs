using CloudSchool.Transport.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CloudSchool.Transport.Data.Configurations
{
    public class ZoneConfiguration : IEntityTypeConfiguration<Zone>
    {
        public void Configure(EntityTypeBuilder<Zone> builder)
        {
            builder
                .Entity<Zone>()
                .HasOne(z => z.Campus)
                .WithMany()
                .HasForeignKey(z => z.CampusId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(z => z.Name).IsRequired();
            builder.Property(z => z.OneWayAmount).IsRequired();
            builder.Property(z => z.ReturnTripAmount).IsRequired();
            builder.Property(z => z.TwoWayAmount).IsRequired();
        }
    }
}
