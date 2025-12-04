using CloudSchool.Transport.Core.Interfaces;
using CloudSchool.Transport.Core.Models.Zone;
using Microsoft.EntityFrameworkCore;

namespace CloudSchool.Transport.Data.Repositories
{
    public class ZoneRepository : IZoneRepository
    {
        private readonly TransportDbContext _context;

        public ZoneRepository(TransportDbContext context)
        {
            _context = context;
        }

        private IQueryable<Zone> GetBaseQuery()
        {
            return _context
                .Zones.Include(z => z.AddedByStaff)
                .Include(z => z.ModifiedByStaff)
                .Include(z => z.Campus)
                .Include(z => z.Company);
        }

        public async Task<Zone?> GetAllAsync()
        {
            return await GetBaseQuery().Where(z => !z.IsDeleted).OrderBy(z => z.Name).ToListAsync();
        }

        public async Task AddAsync(Zone zone)
        {
            await _context.Zones.AddAsync(zone);
        }

        public async Task UpdateAsync(Zone zone)
        {
            _context.Zones.Update(zone);
            return Task.CompletedTask;
        }

        public async Task DeleteAsync(Zone zone)
        {
            _context.Zones.Remove(zone);
            return Task.CompletedTask;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
