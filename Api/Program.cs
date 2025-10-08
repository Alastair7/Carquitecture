using Carquitecture.Application.Features.Vehicles.CreateVehicle.Commands;
using Carquitecture.Application.Features.Vehicles.DeleteVehicle;
using Carquitecture.Application.Features.Vehicles.GetSingleVehicle.Queries;
using Carquitecture.Application.Features.Vehicles.GetVehicles.Queries;
using Carquitecture.Application.Features.Vehicles.UpdateVehicle.Commands;
using Carquitecture.Application.Repositories;
using Carquitecture.Infrastructure;
using Carquitecture.Infrastructure.Data;
using Carquitecture.Infrastructure.Repositories;
using DispatchR.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbConfiguration(builder.Configuration);


builder.Services.AddControllers();

builder.Services.AddScoped<IUnitOfWork>(s => s.GetRequiredService<VehicleContext>());
builder.Services.AddScoped<IVehicleRepository, VehicleRepository>();

builder.Services.AddDispatchR(typeof(CreateVehicleCommandHandler).Assembly);
builder.Services.AddDispatchR(typeof(GetVehicleByIdQueryHandler).Assembly);
builder.Services.AddDispatchR(typeof(GetAllVehiclesQueryHandler).Assembly);
builder.Services.AddDispatchR(typeof(DeleteVehicleCommandHandler).Assembly);
builder.Services.AddDispatchR(typeof(UpdateVehicleCommandHandler).Assembly);

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
