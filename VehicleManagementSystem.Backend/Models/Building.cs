using System.Collections.Generic;

namespace VehicleManagementSystem.Models
{
    public class Building
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Address { get; set; }
        public string? ManagerName { get; set; }
        public string? ContactNumber { get; set; }

        // List of Vehicles associated with the Building
        public ICollection<Vehicle> Vehicles { get; set; }

        // Constructor to initialize collections
        public Building()
        {
            Vehicles = new List<Vehicle>();
        }
    }
}
