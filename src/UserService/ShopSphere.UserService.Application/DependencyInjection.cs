using Microsoft.Extensions.DependencyInjection;
using ShopSphere.UserService.Application.Interfaces;
using ShopSphere.UserService.Application.Services;

namespace ShopSphere.UserService.Application
{
  public static class DependencyInjection
  {
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
      services.AddTransient<IUserService, UserServiceImplementation>();
      return services;
    }
  }
}
