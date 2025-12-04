using CloudSchool.Transport.Core.Interfaces;
using CloudSchool.Transport.Core.Models.Trip;
using Microsoft.EntityFrameworkCore;

namespace CloudSchool.Transport.Data.Repositories
{
    public class TripRepository : ITripRepository
    {
        private readonly TransportDbContext _context;

        public TripRepository(TransportDbContext context)
        {
            _context = context;
        }

        private IQueryable<Trip> GetBaseQuery()
        {
            return _context
                .Trips.Include(t => t.AddedByStaff)
                .Include(t => t.ModifiedByStaff)
                .Include(t => t.Vehicle)
                .Include(t => t.Driver)
                .Include(t => t.Minder)
                .Include(t => t.Stations.OrderBy(s => s.Id))
                .Include(t => t.Routes.Where(r => !r.IsDeleted).OrderBy(r => r.Name));
        }

        public async Task<Trip?> GetByIdAsync(int id)
        {
            return await GetBaseQuery()
                .Where(t => !t.IsDeleted)
                .OrderBy(t => t.Date)
                .ThenBy(t => t.StartTime)
                .ToListAsync();
        }

        public async Task AddAsync(Trip trip)
        {
            await _context.Trips.AddAsync(trip);
        }

        public async Task UpdateAsync(Trip trip)
        {
            _context.Trips.Update(trip);
            return Task.CompletedTask;
        }

        public async Task DeleteAsync(Trip trip)
        {
            _context.Trips.Remove(trip);
            return Task.CompletedTask;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
