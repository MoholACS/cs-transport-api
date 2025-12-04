using CloudSchool.Transport.Core.Models.Station;

public interface IStationRepository
{
    Task<Station?> GetByIdAsync(int id);
    Task<List<Station>> GetAllByRouteIdAsync(int routeId);
    Task AddAsync(Station station);
    Task UpdateAsync(Station station);
    Task DeleteAsync(Station station);
    Task<bool> SaveChangesAsync();
};
