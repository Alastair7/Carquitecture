using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Carquitecture.IntegrationTests;

public class CustomWebApplicationFactory : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        // Revisar para cargar el appsettings de test.
        builder.ConfigureServices(services =>
        {});

        builder.UseEnvironment("Test");
    }
}