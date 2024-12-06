using Microsoft.Extensions.DependencyInjection;
using ShopSphere.OrderService.Application.Interfaces;
using ShopSphere.OrderService.Application.Services;

namespace ShopSphere.OrderService.Application
{
  public static class DependencyInjection
  {
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
      services.AddScoped<IOrderService, OrderServiceImplementation>();
      return services;
    }
  }
}
