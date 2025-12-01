using Microsoft.EntityFrameworkCore;

namespace CloudSchool.Transport.Data;

public class TransportDbContext : DbContext
{
    public TransportDbContext(DbContextOptions<TransportDbContext> options) : base(options)
    {
    }
}
