using CloudSchool.Transport.Core.Models.Route;

public interface IRouteRepository
{
    Task<Route?> GetByIdAsync(int id);
    Task<List<Route>> GetAllAsync();
    Task AddAsync(Route route);
    Task UpdateAsync(Route route);
    Task DeleteAsync(Route route);
    Task<bool> SaveChangesAsync();
}
