using System;

namespace VehicleManagementSystem.Models
{
    public class ServiceRecord
    {
        public int Id { get; set; }

        // Foreign key and navigation property for the associated Vehicle
        public required int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; } = null!;

        // Service details
        public required DateTime ServiceDate { get; set; }
        public string? Description { get; set; }
        public required decimal Cost { get; set; }
        public int? ServiceMileage { get; set; }
        public string? ServiceProvider { get; set; }
        public string? Notes { get; set; }
    }
}