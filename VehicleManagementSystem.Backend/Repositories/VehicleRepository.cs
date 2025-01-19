using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VehicleManagementSystem.Data;
using VehicleManagementSystem.Models;

namespace VehicleManagementSystem.Repositories
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly ApplicationDbContext _context;

        public VehicleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Get a single vehicle by ID
        public async Task<Vehicle?> GetVehicleByIdAsync(int id)
        {
            return await _context.Vehicles.FirstOrDefaultAsync(v => v.Id == id);
        }

        // Get all vehicles
        public async Task<IEnumerable<Vehicle>> GetAllVehiclesAsync()
        {
            return await _context.Vehicles.ToListAsync();
        }

        // Get vehicles belonging to a specific building
        public async Task<IEnumerable<Vehicle>> GetVehiclesByBuildingAsync(int buildingId)
        {
            return await _context.Vehicles
                .Where(v => v.BuildingId == buildingId)
                .ToListAsync();
        }

        // Add a new vehicle
        public async Task AddVehicleAsync(Vehicle vehicle)
        {
            if (vehicle == null)
            {
                throw new ArgumentNullException(nameof(vehicle), "Vehicle cannot be null");
            }

            await _context.Vehicles.AddAsync(vehicle);
            await _context.SaveChangesAsync();
        }

        // Update an existing vehicle
        public async Task UpdateVehicleAsync(Vehicle vehicle)
        {
            if (vehicle == null)
            {
                throw new ArgumentNullException(nameof(vehicle), "Vehicle cannot be null");
            }

            _context.Vehicles.Update(vehicle);
            await _context.SaveChangesAsync();
        }

        // Delete a vehicle by ID
        public async Task DeleteVehicleAsync(int id)
        {
            var vehicle = await GetVehicleByIdAsync(id);
            if (vehicle == null)
            {
                throw new KeyNotFoundException($"Vehicle with ID {id} not found");
            }

            _context.Vehicles.Remove(vehicle);
            await _context.SaveChangesAsync();
        }
    }
}