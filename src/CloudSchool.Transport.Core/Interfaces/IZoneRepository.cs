using CloudSchool.Transport.Core.Models.Zone;

public interface IZoneRepository
{
    Task<Zone?> GetByIdAsync(int id);
    Task<List<Zone>> GetAllAsync();
    Task AddAsync(Zone zone);
    Task UpdateAsync(Zone zone);
    Task DeleteAsync(Zone zone);
    Task<bool> SaveChangesAsync();
}
