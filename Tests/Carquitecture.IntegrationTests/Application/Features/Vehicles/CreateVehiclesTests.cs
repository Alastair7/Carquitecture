using Carquitecture.API.Controllers.Vehicle.Requests;
using Carquitecture.Application.Features.Vehicles.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http.Json;

namespace Carquitecture.IntegrationTests.Application.Features.Vehicles;

// Revisar opciones a parte de IClassFixture y para qué sirve cada una.
public class CreateVehiclesTests : IClassFixture<CustomWebApplicationFactory>
{
    private readonly HttpClient _client;
    private readonly CustomWebApplicationFactory _factory;
    public CreateVehiclesTests(CustomWebApplicationFactory factory)
    {
        _factory = factory;
        _client = factory.CreateClient(new WebApplicationFactoryClientOptions 
        {
            AllowAutoRedirect = false
        });
    }
    [Fact]
    public async Task CreateVehicle_ReturnsSuccessStatusCode()
    {
        // Arrange
        var client = _factory.CreateClient();
        var newVehicle = new CreateVehicleRequest
        {
            LicensePlate = new LicensePlateDto("ABC123", "ES"),
            Type = "Renault",
            Owners =
            [
                new("Test", "User", true)
            ],
            Seats =
            [
                new CreateSeatDto("Leather", "Black")
            ]
        };
        // Act
        var response = await client.PostAsJsonAsync("/api/vehicles", newVehicle);
        // Assert
        response.EnsureSuccessStatusCode();
    }
}
