using Carquitecture.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Carquitecture.Infrastructure;

public static class StartupExtensions
{
    public static IServiceCollection AddDbConfiguration(this IServiceCollection services, IConfiguration configuration) 
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        return services.AddDbContext<VehicleContext>(
            options => options.UseNpgsql(connectionString)
            );
    }
}