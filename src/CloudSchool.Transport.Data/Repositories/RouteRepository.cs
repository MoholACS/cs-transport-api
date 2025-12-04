using CloudSchool.Transport.Core.Interfaces;
using CloudSchool.Transport.Core.Models.Route;
using Microsoft.EntityFrameworkCore;

namespace CloudSchool.Transport.Data.Repositories
{
    public class RouteRepository : IRouteRepository
    {
        private readonly TransportDbContext _context;

        public RouteRepository(TransportDbContext context)
        {
            _context = context;
        }

        private IQueryable<Route> GetBaseQuery()
        {
            return _context
                .Routes.Include(r => r.AddedByStaff)
                .Include(r => r.ModifiedByStaff)
                .Include(r => r.Vehicle)
                .Include(r => r.Driver)
                .Include(r => r.Minder)
                .Include(r => r.Stations.OrderBy(s => s.Id))
                .Include(r => r.Trips.Where(t => !t.IsDeleted).OrderBy(t => t.Date));
        }

        public async Task<Route?> GetByIdAsync(int id)
        {
            return await GetBaseQuery().FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<List<Route>> GetAllAsync()
        {
            return await GetBaseQuery().ToListAsync();
        }

        public async Task AddAsync(Route route)
        {
            await _context.Routes.AddAsync(route);
        }

        public Task UpdateAsync(Route route)
        {
            _context.Routes.Update(route);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(Route route)
        {
            _context.Routes.Remove(route);
            return Task.CompletedTask;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
