using Carquitecture.Application.Features.Vehicles.CreateVehicle.Commands;
using Carquitecture.Application.Features.Vehicles.DeleteVehicle;
using Carquitecture.Application.Features.Vehicles.GetSingleVehicle.Queries;
using Carquitecture.Application.Features.Vehicles.GetVehicles.Queries;
using Carquitecture.Application.Features.Vehicles.UpdateVehicle.Commands;
using Carquitecture.Application.Repositories;
using Carquitecture.Infrastructure;
using Carquitecture.Infrastructure.Data;
using Carquitecture.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbConfiguration(builder.Configuration);


builder.Services.AddControllers();

builder.Services.AddScoped<ICreateVehicleCommandHandler, CreateVehicleCommandHandler>();
builder.Services.AddScoped<IGetAllVehiclesQueryHandler, GetAllVehiclesQueryHandler>();
builder.Services.AddScoped<IGetVehicleByIdQueryHandler, GetVehicleByIdQueryHandler>();
builder.Services.AddScoped<IUpdateVehicleCommandHandler, UpdateVehicleCommandHandler>();
builder.Services.AddScoped<IDeleteVehicleCommandHandler, DeleteVehicleCommandHandler>();

builder.Services.AddScoped<IUnitOfWork, VehicleContext>();
builder.Services.AddScoped<IVehicleRepository, VehicleRepository>();

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
