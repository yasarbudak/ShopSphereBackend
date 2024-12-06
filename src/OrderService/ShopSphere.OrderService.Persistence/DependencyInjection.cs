using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShopSphere.OrderService.Domain.Interfaces;
using ShopSphere.OrderService.Persistence.DbContexts;
using ShopSphere.OrderService.Persistence.Repositories;

namespace ShopSphere.OrderService.Persistence
{
  public static class DependencyInjection
  {
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
      var connectionString = configuration.GetConnectionString("OrderServiceConnection");
      services.AddDbContext<OrderDbContext>(options =>
          options.UseNpgsql(connectionString));

      services.AddScoped<IOrderRepository, OrderRepository>();

      return services;
    }
  }
}
