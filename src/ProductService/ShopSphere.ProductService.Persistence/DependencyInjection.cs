using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShopSphere.ProductService.Domain.Interfaces;
using ShopSphere.ProductService.Persistence.DbContexts;
using ShopSphere.ProductService.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSphere.ProductService.Persistence
{
  public static class DependencyInjection
  {
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
      var connectionString = configuration.GetConnectionString("OrderServiceConnection");
      services.AddDbContext<ProductDbContext>(options =>
          options.UseNpgsql(connectionString));

      services.AddScoped<IProductRepository, ProductRepository>();

      return services;
    }
  }
}
