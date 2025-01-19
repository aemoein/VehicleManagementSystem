using System.Collections.Generic;
using System.Threading.Tasks;
using VehicleManagementSystem.Models;

namespace VehicleManagementSystem.Repositories
{
    public interface IEmployeeRepository
    {
        Task<Employee> GetEmployeeByIdAsync(int id);
        Task<IEnumerable<Employee>> GetAllEmployeesAsync();
        Task AddEmployeeAsync(Employee employee);
        Task UpdateEmployeeAsync(Employee employee);
        Task DeleteEmployeeAsync(int id);
        Task<IEnumerable<Employee>> GetEmployeesByDepartmentAsync(string department);
        Task<Employee> GetEmployeeByEmailAsync(string email);
    }
}