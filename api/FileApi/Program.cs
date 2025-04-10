using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Cors.Infrastructure;

namespace MyApi
{
    //best naming convention ever...
    public class Program
    {
        public static void Main(string[] args)
        {
            // Create and run the host
            CreateHostBuilder(args).Build().Run();
        }

        // Create the host builder
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    // Set the API port and configure CORS
                    Console.Write("Starting API on port 3001\n");
                    webBuilder.UseUrls("http://localhost:3001");
                    webBuilder.ConfigureServices(services =>
                    {
                        // Add controllers and CORS services
                        services.AddControllers();
                        services.AddCors(options =>
                        {
                            options.AddPolicy("AllowSpecificOrigins",
                                builder =>
                                {
                                    // Allow requests from localhost:3000
                                    builder.WithOrigins("http://localhost:3000")
                                           .AllowAnyMethod()
                                           .AllowAnyHeader()
                                           .AllowCredentials();
                                });
                        });
                    });
                    webBuilder.Configure(app =>
                    {
                        // Configure the request pipeline
                        app.UseRouting();
                        app.UseCors("AllowSpecificOrigins");
                        app.UseEndpoints(endpoints =>
                        {
                            // Map controllers to endpoints
                            endpoints.MapControllers();
                        });
                    });
                });
    }
}