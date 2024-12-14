using Microsoft.EntityFrameworkCore;
using ShopSphere.OrderService.Application;
using ShopSphere.OrderService.Application.Interfaces;
using ShopSphere.OrderService.Application.Services;
using ShopSphere.OrderService.Infrastructure;
using ShopSphere.OrderService.Persistence;
using ShopSphere.OrderService.Persistence.DbContexts;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<OrderDbContext>(options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("OrderServiceConnection")));
builder.Services.AddScoped<IOrderService, OrderServiceImplementation>();

// Add services to the container.

// DependencyInjection sýnýflarýný ekleme
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices();
builder.Services.AddPersistenceServices(builder.Configuration);

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
