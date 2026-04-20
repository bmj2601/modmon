using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Shared.Database;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration = null)
    {
        if (configuration == null)
        {
            // For tests - use InMemory
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseInMemoryDatabase("ModMonDb"));
        }
        else
        {
            // For production - use SQL Server
            var connectionString = configuration.GetConnectionString("DefaultConnection")
                ?? "Server=(localdb)\\mssqllocaldb;Database=ModMonDb;Trusted_Connection=True;";

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
        }

        return services;
    }
}