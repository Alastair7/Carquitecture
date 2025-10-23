using Carquitecture.Application.Features.Vehicles.CreateVehicle.Commands;
using Carquitecture.Application.Repositories;
using Carquitecture.Application.Shared.Behaviors;
using Carquitecture.Infrastructure;
using Carquitecture.Infrastructure.Data;
using Carquitecture.Infrastructure.Repositories;
using DispatchR.Extensions;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbConfiguration(builder.Configuration);
builder.Services.AddLogging();


builder.Services.AddControllers();

builder.Services.AddScoped<IUnitOfWork>(s => s.GetRequiredService<VehicleContext>());
builder.Services.AddScoped<IVehicleRepository, VehicleRepository>();

builder.Services.AddTransient<IValidator<CreateVehicleCommand>, CreateVehicleCommandValidator>();

builder.Services.AddDispatchR(typeof(CreateVehicleCommandHandler).Assembly, withPipelines: true);

builder.Services.AddDispatchR(options =>
{
    options.Assemblies.Add(typeof(CreateVehicleCommandHandler).Assembly);
    options.RegisterPipelines = true;
    options.PipelineOrder = [
        typeof(LoggingBehavior<,>),
        typeof(ValidationBehavior<,>)
        ];
});

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
