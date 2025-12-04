using CloudSchool.Transport.Core.Interfaces;
using CloudSchool.Transport.Core.Models.Vehicle;
using Microsoft.EntityFrameworkCore;

namespace CloudSchool.Transport.Data.Repositories
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly TransportDbContext _context;

        public VehicleRepository(TransportDbCDontext context)
        {
            _context = context;
        }

        public async Task<Vehicle?> GetByIdAsync(int id)
        {
            return await _context
                .Vehicles.Include(v => v.AddedByStaff)
                .Include(v => v.ModifiedByStaff)
                .FirstOrDefaultAsync(v => v.Id == id);
        }

        public async Task<List<Vehicle>> GetAllAsync()
        {
            return await _context
                .Vehicles.Include(v => v.AddedByStaff)
                .Include(v => v.ModifiedByStaff)
                .ToListAsync();
        }

        public async Task AddAsync(Vehicle vehicle)
        {
            await _context.Vehicles.AddAsync(vehicle);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
