using Carquitecture.Application.Features.Vehicles.CreateVehicle.Commands;
using Carquitecture.Application.Repositories;
using Carquitecture.Application.Shared.Behaviors;
using Carquitecture.Application.Shared.ErrorHandling;
using Carquitecture.Infrastructure;
using Carquitecture.Infrastructure.Data;
using Carquitecture.Infrastructure.Repositories;
using DispatchR.Abstractions.Send;
using DispatchR.Extensions;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbConfiguration();
builder.Services.AddLogging();


builder.Services.AddControllers();

builder.Services.AddScoped<IUnitOfWork>(s => s.GetRequiredService<VehicleContext>());
builder.Services.AddScoped<IVehicleRepository, VehicleRepository>();

builder.Services.AddValidatorsFromAssemblyContaining<CreateVehicleCommand>();


builder.Services.AddDispatchR(typeof(CreateVehicleCommandHandler).Assembly, withPipelines: false);

// DispatchR Pipeline Behaviors
// Had to set "withPipelines" to false to be able to register custom pipeline behaviors
// LoggingBehavior implements ICommand so it will be applied only to commands and DispatchR does not know how to register it automatically
builder.Services.AddScoped(typeof(IPipelineBehavior<CreateVehicleCommand,Task<Result>>), typeof(LoggingBehavior<CreateVehicleCommand,Result>));
builder.Services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }
