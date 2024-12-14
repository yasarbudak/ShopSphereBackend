using Microsoft.Extensions.DependencyInjection;
using ShopSphere.ProductService.Application.Interfaces;
using ShopSphere.ProductService.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSphere.ProductService.Application
{
  public static class DependencyInjection
  {
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
      services.AddTransient<IProductService, ProductServiceImplementation>();
      return services;
    }
  }
}
