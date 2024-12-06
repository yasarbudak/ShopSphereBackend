﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSphere.OrderService.Domain.Enums
{
  public enum OrderStatus
  {
    Pending,
    Processing,
    Shipped,
    Delivered,
    Canceled
  }
}
