using System;

namespace VehicleManagementSystem.Models
{
    public class Fine
    {
        public int Id { get; set; }

        public required int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; } = null!;

        public required DateTime IssuedDate { get; set; }
        public required decimal Amount { get; set; }
        public required string Reason { get; set; } // Reason for the fine (e.g., Speeding, Parking Violation)
        public string? IssuedBy { get; set; } // Issuing Authority (e.g., Police Department)
        public bool IsPaid { get; set; }
        public DateTime? PaymentDate { get; set; }
        public string? Notes { get; set; } // Additional comments or details about the fine
    }
}