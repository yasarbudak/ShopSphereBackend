using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShopSphere.UserService.Domain.Interfaces;
using ShopSphere.UserService.Persistence.DbContexts;
using ShopSphere.UserService.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSphere.UserService.Persistence
{
  public static class DependencyInjection
  {
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
    {
      // Register database-related services, repositories, etc.
      services.AddDbContext<ApplicationDbContext>(options =>
          options.UseSqlServer("YourConnectionString"));  // Example with Entity Framework

      services.AddScoped<IUserRepository, UserRepository>();
      return services;
    }
  }
}
