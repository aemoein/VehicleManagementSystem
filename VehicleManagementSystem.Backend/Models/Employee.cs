using System.Collections.Generic;

namespace VehicleManagementSystem.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string PhoneNumber { get; set; }
        public required string Department { get; set; }
        public required string Role { get; set; } // Role of the Employee (e.g., Driver, Manager, etc.)

        // List of Checkout Requests by the Employee
        public ICollection<CheckoutRequest> CheckoutRequests { get; set; }

        // Constructor to initialize collections
        public Employee()
        {
            CheckoutRequests = new List<CheckoutRequest>();
        }
    }
}