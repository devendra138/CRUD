using APICRUDOperations;
using AutoMapper;
using BusinessLogic.IServices;
using BusinessLogic.Services;
using DataAccess.IRepository;
using DataAccess.Models;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CompanyDetailsContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Add services to the container.
builder.Services.AddTransient<IRegistrationService, RegistrationService>();
builder.Services.AddTransient<IRegistrationRepository, RegistrationRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register AutoMapper and scan for all profiles in the current assembly
builder.Services.AddAutoMapper(typeof(Program).Assembly);

var app = builder.Build();

// Verify AutoMapper configuration
using (var scope = app.Services.CreateScope())
{
    var mapper = scope.ServiceProvider.GetRequiredService<IMapper>();
    try
    {
        mapper.ConfigurationProvider.AssertConfigurationIsValid(); // This will throw an exception if the configuration is invalid
    }
    catch (Exception ex)
    {
        Console.WriteLine($"AutoMapper configuration is invalid: {ex.Message}");
    }
}

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
