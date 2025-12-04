using CloudSchool.Transport.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace CloudSchool.Transport.Data;

public class TransportDbContext : DbContext
{
    public TransportDbContext(DbContextOptions<TransportDbContext> options)
        : base(options) { }

    public DbSet<Route> Routes { get; set; }
    public DbSet<Staff> Staff { get; set; }
    public DbSet<Station> Stations { get; set; }
    public DbSet<Trip> Trips { get; set; }
    public DbSet<Vehicle> Vehicles { get; set; }
    public DbSet<Zone> Zones { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new RouteConfiguration());
        modelBuilder.ApplyConfiguration(new TripConfiguration());
        modelBuilder.ApplyConfiguration(new VehicleConfiguration());

        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            if (typeof(BaseModel).IsAssignableFrom(entityType.ClrType))
            {
                var configType = typeof(BaseModelConfiguration<>).MakeGenericType(entityType.ClrType);
                modelBuilder.ApplyConfiguration(configType);

                var configuration = Activator.CreateInstance(configType)
            }
        }
    }
    base.OnModelCreating(modelBuilder);
}
