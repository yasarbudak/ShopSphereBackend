using Microsoft.Extensions.DependencyInjection;
using ShopSphere.UserService.Infrastructure.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSphere.UserService.Infrastructure
{
  public static class DependencyInjection
  {
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
      //Register infrastructure services like logging or third-party services
      services.AddScoped<ILoggingService, LoggingService>();
      return services;
    }
  }
}
