using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace VehicleManagementSystem.Backend
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
                    webBuilder.ConfigureServices(services =>
                    {
                        // Add services to the container
                        services.AddControllers();
                    })
                    .Configure(app =>
                    {
                        // Configure the HTTP request pipeline
                        app.UseRouting();

                        // Add endpoints to the routing system
                        app.UseEndpoints(endpoints =>
                        {
                            endpoints.MapControllers(); // This tells ASP.NET to map controllers to the URL
                        });
                    });
                });
    }
}