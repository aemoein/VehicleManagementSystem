using System.Collections.Generic;
using System.Threading.Tasks;
using VehicleManagementSystem.Models;

namespace VehicleManagementSystem.Repositories
{
    public interface IVehicleRepository
    {
        Task<Vehicle?> GetVehicleByIdAsync(int id);
        Task<IEnumerable<Vehicle>> GetAllVehiclesAsync();
        Task<IEnumerable<Vehicle>> GetVehiclesByBuildingAsync(int buildingId);
        Task AddVehicleAsync(Vehicle vehicle);
        Task UpdateVehicleAsync(Vehicle vehicle);
        Task DeleteVehicleAsync(int id);
    }
}