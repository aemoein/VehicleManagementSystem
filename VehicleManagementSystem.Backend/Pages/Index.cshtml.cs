using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;
using VehicleManagementSystem.Models;
using VehicleManagementSystem.Services;

namespace VehicleManagementSystem.Backend.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IEmployeeService _employeeService;

        // Constructor to inject dependencies
        public IndexModel(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        // Properties to pass to the Razor page
        public IEnumerable<Employee> Employees { get; set; }

        // OnGet method to handle HTTP GET requests for the Index page
        public async Task OnGetAsync()
        {
            // Fetch the list of employees and pass it to the Razor page
            Employees = await _employeeService.GetAllEmployeesAsync();
        }
    }
}