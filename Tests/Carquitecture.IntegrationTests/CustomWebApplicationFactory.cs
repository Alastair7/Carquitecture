using Carquitecture.Infrastructure;
using Carquitecture.Infrastructure.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Carquitecture.IntegrationTests;

public class CustomWebApplicationFactory : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.UseEnvironment("Test");
        // Revisar para cargar el appsettings de test.
        builder.ConfigureAppConfiguration((context, config) => 
        {
            config.SetBasePath(Directory.GetCurrentDirectory());

            config.AddJsonFile("appsettings.json", optional: false);
            config.AddJsonFile("appsettings.Test.json", optional: true);
        });
        builder.ConfigureServices(services =>
        {
        });

    }
}