using CloudSchool.Transport.Core.Models;
using CloudSchool.Transport.Core.Models.Vehicle;

public interface IVehicleRepository
{
    Task<Vehicle?> GetByIdAsync(int id);
    Task<List<Vehicle>> GetAllAsync();
    Task AddAsync(Vehicle vehicle);
    Task UpdateAsync(Vehicle vehicle);
    Task DeleteAsync(Vehicle vehicle);
    Task<bool> SaveChangesAsync();
}
