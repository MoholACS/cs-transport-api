using CloudSchool.Transport.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class BaseModelConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseModel
{
    public void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.HasKey(b => b.Id);
        builder.Property(b => b.Id).ValueGeneratedOnAdd();

        // Handle Added By Staff relationship using BaseModel
        builder
            .HasOne(e => e.AddedByStaff)
            .WithMany()
            .HasForeignKey(e => e.AddedByStaffId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);

        // Handle Modified By Staff relationship using BaseModel
        builder
            .HasOne(e => e.ModifiedByStaff)
            .WithMany()
            .HasForeignKey(e => e.ModifiedByStaffId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);

        // Handle isDeleted property just naturally default to false
        builder.Property(e => e.isDeleted).HasDefaultValue(false);
    }
}
