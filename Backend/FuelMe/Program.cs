using FuelMe.Helpers;
using FuelMe.Services;

using MongoDB.Driver;

using Microsoft.Extensions.Options;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<FuelMeDatabaseHelper>(builder.Configuration.GetSection("FuelMeDatabaseSettings"));
builder.Services.AddSingleton<IFuelMeDatabaseHelper>(sp => sp.GetRequiredService<IOptions<FuelMeDatabaseHelper>>().Value);
builder.Services.AddSingleton<IMongoClient>(s => new MongoClient(builder.Configuration.GetValue<string>("FuelMeDatabaseSettings:ConnectionString")));
builder.Services.AddScoped<IFuelTypeService, FuelTypeService>();
builder.Services.AddScoped<IVehicleTypeService, VehicleTypeService>();
builder.Services.AddScoped<IFuelStatioService, FuelStatioService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IFuelInventoryService, FuelInventoryService>();
builder.Services.AddScoped<IVehicleQueueService, VehicleQueueService>();
builder.Services.AddScoped<IVehicleService, VehicleService>();

builder.Services.AddControllers();
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

app.UseCors("corsapp");

// app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();

app.Run();
