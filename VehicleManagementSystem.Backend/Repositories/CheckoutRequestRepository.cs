using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VehicleManagementSystem.Data;
using VehicleManagementSystem.Models;

namespace VehicleManagementSystem.Repositories
{
    public class CheckoutRequestRepository : ICheckoutRequestRepository
{
    private readonly ApplicationDbContext _context;

    public CheckoutRequestRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<CheckoutRequest?> GetCheckoutRequestByIdAsync(int id)
    {
        return await _context.CheckoutRequests
            .Include(r => r.Vehicle)
            .Include(r => r.Employee)
            .FirstOrDefaultAsync(r => r.Id == id);
    }

    public async Task<IEnumerable<CheckoutRequest>> GetAllCheckoutRequestsAsync()
    {
        return await _context.CheckoutRequests
            .Include(r => r.Vehicle)
            .Include(r => r.Employee)
            .ToListAsync();
    }

    public async Task<IEnumerable<CheckoutRequest>> GetRequestsByEmployeeIdAsync(int employeeId)
    {
        return await _context.CheckoutRequests
            .Where(r => r.EmployeeId == employeeId)
            .ToListAsync();
    }

    public async Task<IEnumerable<CheckoutRequest>> GetRequestsByVehicleIdAsync(int vehicleId)
    {
        return await _context.CheckoutRequests
            .Where(r => r.VehicleId == vehicleId)
            .ToListAsync();
    }

    public async Task AddCheckoutRequestAsync(CheckoutRequest request)
    {
        _context.CheckoutRequests.Add(request);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateCheckoutRequestAsync(CheckoutRequest request)
    {
        _context.CheckoutRequests.Update(request);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteCheckoutRequestAsync(int id)
    {
        var request = await GetCheckoutRequestByIdAsync(id);
        if (request != null)
        {
            _context.CheckoutRequests.Remove(request);
            await _context.SaveChangesAsync();
        }
    }
}

}