using CloudSchool.Transport.Core.Interfaces;
using CloudSchool.Transport.Core.Models.Station;
using Microsoft.EntityFrameworkCore;

namespace CloudSchool.Tranport.Data.Repositories
{
    public class StationRepository : IStationRepository
    {
        private readonly TransportDbContext _context;

        public StationRepository(TransportDbContext context)
        {
            _context = context;
        }

        private IQueryable<Station> GetBaseQuery()
        {
            return _context
                .Stations.Include(s => s.AddedByStaff)
                .Include(s => s.ModifiedByStaff)
                .Include(s => s.Route);
        }

        public async Task<Station?> GetByIdAsync(int id)
        {
            return await GetBaseQuery().FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<List<Station>> GetAllByRouteIdAsync(int routeId)
        {
            return await GetBaseQuery()
                .Where(s => s.RouteId == routeId && !IsDeleted)
                .OrderBy(s => s.Name)
                .ToListAsync();
        }

        public async Task AddAsync(Station station)
        {
            await _context.Stations.AddAsync(station);
        }

        public async Task UpdateAsync(Station station)
        {
            _context.Stations.Update(station);
            return Task.CompletedTask;
        }

        public async Task DeleteAsync(Station station)
        {
            _context.Stations.Remove(station);
            return Task.CompletedTask;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
