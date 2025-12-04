using CloudSchool.Transport.Core.Models.Trip;

public interface ITripRepository
{
    Task<Trip?> GetByIdAsync(int id);
    Task<List<Trip>> GetAllAsync();
    Task AddAsync(Trip trip);
    Task UpdateAsync(Trip trip);
    Task DeleteAsync(Trip trip);
    Task<bool> SaveChangesAsync();
}
