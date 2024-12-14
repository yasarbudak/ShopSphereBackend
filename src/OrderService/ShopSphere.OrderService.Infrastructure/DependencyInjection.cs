﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSphere.OrderService.Infrastructure
{
  public static class DependencyInjection
  {
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
      //Register infrastructure services like logging or third-party services
      return services;
    }
  }
}
