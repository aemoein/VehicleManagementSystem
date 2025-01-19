using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using VehicleManagementSystem.Models;

namespace VehicleManagementSystem.Data
{
    public static class SeedData // Ensure class is static and public if you need it to be.
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                // Ensure the database is created and apply migrations (if any)
                context.Database.Migrate(); // Applies any pending migrations to the database

                // Seed Buildings
                var buildings = new[]
                {
                    new Building { Name = "Headquarters", Address = "123 Main St" },
                    new Building { Name = "Warehouse", Address = "456 Industrial Blvd" },
                    new Building { Name = "Branch Office", Address = "789 Elm St" }
                };
                context.Buildings.AddRange(buildings);
                context.SaveChanges();

                // Seed Vehicles
                var vehicles = new[]
                {
                    new Vehicle
                    {
                        LicensePlate = "ABC123",
                        Make = "Toyota",
                        Model = "Camry",
                        Year = 2020,
                        Color = "Blue",
                        Mileage = 12000,
                        RegistrationExpiryDate = new DateTime(2025, 12, 31),
                        IsAvailable = true,
                        BuildingId = buildings[0].Id
                    },
                    new Vehicle
                    {
                        LicensePlate = "XYZ789",
                        Make = "Honda",
                        Model = "Civic",
                        Year = 2018,
                        Color = "Red",
                        Mileage = 35000,
                        RegistrationExpiryDate = new DateTime(2025, 06, 30),
                        IsAvailable = false,
                        BuildingId = buildings[1].Id
                    },
                    new Vehicle
                    {
                        LicensePlate = "DEF456",
                        Make = "Ford",
                        Model = "F-150",
                        Year = 2019,
                        Color = "Black",
                        Mileage = 25000,
                        RegistrationExpiryDate = new DateTime(2025, 09, 30),
                        IsAvailable = true,
                        BuildingId = buildings[2].Id
                    }
                };
                context.Vehicles.AddRange(vehicles);
                context.SaveChanges();

                // Seed Employees
                var employees = new[]
                {
                    new Employee { FirstName = "John", LastName = "Doe", Email = "johndoe@example.com", PhoneNumber = "+201008956099" , Department = "Logistics", Role = "Driver" },
                    new Employee { FirstName = "Jane", LastName = "Smith", Email = "janesmith@example.com", PhoneNumber = "+201008956099" , Department = "IT", Role = "Engineer" },
                    new Employee { FirstName = "Alice", LastName = "Brown", Email = "alicebrown@example.com", PhoneNumber = "+201008956099" , Department = "HR", Role = "Manager" }
                };
                context.Employees.AddRange(employees);
                context.SaveChanges();

                // Seed Checkout Requests
                var checkoutRequests = new[]
                {
                    new CheckoutRequest { VehicleId = vehicles[0].Id, EmployeeId = employees[0].Id, RequestDate = DateTime.Now, StartDate = DateTime.Now.AddDays(1), Purpose = "Delivery", Status = "Pending", StartMileage = 30000.00, EndMileage = 30022.15, Notes = "Tires Might Need Maintainance"},
                    new CheckoutRequest { VehicleId = vehicles[1].Id, EmployeeId = employees[1].Id, RequestDate = DateTime.Now.AddDays(-3), StartDate = DateTime.Now.AddDays(-2), EndDate = DateTime.Now, Purpose = "Delivery", Status = "Completed" }
                };
                context.CheckoutRequests.AddRange(checkoutRequests);
                context.SaveChanges();
            }
        }
    }
}