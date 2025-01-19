using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using VehicleManagementSystem.Data;
using VehicleManagementSystem.Services;
using VehicleManagementSystem.Repositories; // Add this namespace for the repository

namespace VehicleManagementSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureServices((context, services) =>
                    {
                        var connectionString = context.Configuration.GetConnectionString("DefaultConnection")
                            ?? throw new InvalidOperationException("Connection string not found.");

                        // Add DbContext with MySQL
                        services.AddDbContext<ApplicationDbContext>(options =>
                            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

                        // Register IEmployeeRepository and EmployeeRepository
                        services.AddScoped<IEmployeeRepository, EmployeeRepository>(); // Register the repository

                        // Register ICheckoutRequestRepository and CheckoutRequestRepository
                        services.AddScoped<ICheckoutRequestRepository, CheckoutRequestRepository>(); // Register the repository

                        // Register IEmployeeService and EmployeeService
                        services.AddScoped<IEmployeeService, EmployeeService>(); // Register the service

                        // Add services for Razor Pages
                        services.AddRazorPages();
                    })
                    .Configure(app =>
                    {
                        var env = app.ApplicationServices.GetRequiredService<IHostEnvironment>();

                        if (env.IsDevelopment())
                        {
                            app.UseDeveloperExceptionPage();
                        }
                        else
                        {
                            app.UseExceptionHandler("/Error");
                            app.UseHsts();
                        }

                        app.UseHttpsRedirection();
                        app.UseStaticFiles();

                        app.UseRouting();

                        app.UseEndpoints(endpoints =>
                        {
                            // Map Razor Pages
                            endpoints.MapRazorPages();
                        });
                    });
                });
    }
}