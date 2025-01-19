using System.Collections.Generic;
using System.Threading.Tasks;
using VehicleManagementSystem.Models;

namespace VehicleManagementSystem.Repositories
{
    public interface ICheckoutRequestRepository
{
    Task<CheckoutRequest?> GetCheckoutRequestByIdAsync(int id);
    Task<IEnumerable<CheckoutRequest>> GetAllCheckoutRequestsAsync();
    Task<IEnumerable<CheckoutRequest>> GetRequestsByEmployeeIdAsync(int employeeId);
    Task<IEnumerable<CheckoutRequest>> GetRequestsByVehicleIdAsync(int vehicleId);
    Task AddCheckoutRequestAsync(CheckoutRequest request);
    Task UpdateCheckoutRequestAsync(CheckoutRequest request);
    Task DeleteCheckoutRequestAsync(int id);
}

}