using Microsoft.EntityFrameworkCore;
using VehicleManagementSystem.Models;

namespace VehicleManagementSystem.Data
{
    public class ApplicationDbContext : DbContext
    {
        // Constructor
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            // Database migration configuration
            Database.EnsureCreated(); // Create the database if it doesn't exist
        }

        // DbSet properties for each entity
        public DbSet<Vehicle> Vehicles { get; set; } = null!;
        public DbSet<Employee> Employees { get; set; } = null!;
        public DbSet<CheckoutRequest> CheckoutRequests { get; set; } = null!;
        public DbSet<Fine> Fines { get; set; } = null!;
        public DbSet<ServiceRecord> ServiceRecords { get; set; } = null!;
        public DbSet<Building> Buildings { get; set; } = null!;

        // Fluent API configurations
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Vehicle>()
                .HasOne(v => v.Building)
                .WithMany(b => b.Vehicles)
                .HasForeignKey(v => v.BuildingId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascading delete

            // CheckoutRequest -> Vehicle (Many-to-One)
            modelBuilder.Entity<CheckoutRequest>()
                .HasOne(cr => cr.Vehicle)
                .WithMany(v => v.CheckoutRequests)
                .HasForeignKey(cr => cr.VehicleId)
                .OnDelete(DeleteBehavior.Restrict);

            // CheckoutRequest -> Employee (Many-to-One)
            modelBuilder.Entity<CheckoutRequest>()
                .HasOne(cr => cr.Employee)
                .WithMany(e => e.CheckoutRequests)
                .HasForeignKey(cr => cr.EmployeeId)
                .OnDelete(DeleteBehavior.Restrict);

            // Fine -> Vehicle (Many-to-One)
            modelBuilder.Entity<Fine>()
                .HasOne(f => f.Vehicle)
                .WithMany(v => v.Fines)
                .HasForeignKey(f => f.VehicleId)
                .OnDelete(DeleteBehavior.Restrict);

            // ServiceRecord -> Vehicle (Many-to-One)
            modelBuilder.Entity<ServiceRecord>()
                .HasOne(sr => sr.Vehicle)
                .WithMany(v => v.ServiceRecords)
                .HasForeignKey(sr => sr.VehicleId)
                .OnDelete(DeleteBehavior.Restrict);

            // Unique Indexes
            modelBuilder.Entity<Vehicle>()
                .HasIndex(v => v.LicensePlate)
                .IsUnique();

            modelBuilder.Entity<Building>()
                .HasIndex(b => b.Name)
                .IsUnique();

            // Additional Constraints on Vehicle (if necessary)
            modelBuilder.Entity<Vehicle>()
                .Property(v => v.LicensePlate)
                .IsRequired()
                .HasMaxLength(10);
        }
    }
}