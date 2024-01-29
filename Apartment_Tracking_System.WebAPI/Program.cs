using Apartment_Tracking_System.Application;
using Apartment_Tracking_System.Infrastructure;
using Apartment_Tracking_System.Persistence;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

var services=builder.Services;
var configuration=builder.Configuration;
var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(config)
    .CreateLogger();

builder.Services.AddControllers();
services.AddInfrastructureServices();
services.AddApplicationService();
services.AddPersistenceServices(configuration);

// Add services to the container.


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
