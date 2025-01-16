using System;

namespace VehicleManagementSystem.Models
{
    public class CheckoutRequest
    {
        public int Id { get; set; }
        public required int VehicleId { get; set; }
        public required int EmployeeId { get; set; }

        // Navigation properties
        public Vehicle Vehicle { get; set; } = null!;
        public Employee Employee { get; set; } = null!;
        
        public required DateTime RequestDate { get; set; } 
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public required string Purpose { get; set; }
        public required string Status { get; set; } // Status of the request (e.g., Pending, Approved, Rejected, Completed)

        // Additional properties
        public double? StartMileage { get; set; }
        public double? EndMileage { get; set; }
        public string? Notes { get; set; }
    }
}