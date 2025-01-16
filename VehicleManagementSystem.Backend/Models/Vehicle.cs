using System;
using System.Collections.Generic;

namespace VehicleManagementSystem.Models
{
    public class Vehicle
    {
        public int Id { get; set; }

        public required string LicensePlate { get; set; }
        public required string Make { get; set; }
        public required string Model { get; set; }
        public required int Year { get; set; }
        public required string Color { get; set; }
        public double? Mileage { get; set; }
        public required DateTime RegistrationExpiryDate { get; set; }
        public required bool IsAvailable { get; set; }

        public required int BuildingId { get; set; }

        public Building Building { get; set; } = null!;

        public ICollection<ServiceRecord> ServiceRecords { get; set; }
        public ICollection<CheckoutRequest> CheckoutRequests { get; set; }
        public ICollection<Fine> Fines { get; set; }


        // Constructor to initialize collections
        public Vehicle()
        {
            ServiceRecords = new List<ServiceRecord>();
            CheckoutRequests = new List<CheckoutRequest>();
            Fines = new List<Fine>();
        }
    }
}