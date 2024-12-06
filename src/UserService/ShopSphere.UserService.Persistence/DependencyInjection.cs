using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShopSphere.UserService.Domain.Interfaces;
using ShopSphere.UserService.Persistence.DbContexts;
using ShopSphere.UserService.Persistence.Repositories;

namespace ShopSphere.UserService.Persistence
{
  public static class DependencyInjection
  {
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
      services.AddDbContext<ApplicationDbContext>(options =>
          options.UseNpgsql(configuration.GetConnectionString("UserServiceConnection")));

      services.AddScoped<IUserRepository, UserRepository>();

      return services;
    }
  }
}
