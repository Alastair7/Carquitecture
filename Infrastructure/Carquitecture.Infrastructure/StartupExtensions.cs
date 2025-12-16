using Carquitecture.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Carquitecture.Infrastructure;

public static class StartupExtensions
{
    public static IServiceCollection AddDbConfiguration(this IServiceCollection services) 
    {
        services.AddDbContext<VehicleContext>((sp, options) => 
        {
            var configuration = sp.GetRequiredService<IConfiguration>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            options.UseNpgsql(connectionString);
        });

        return services;
    }
}