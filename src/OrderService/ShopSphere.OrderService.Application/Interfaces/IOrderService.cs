using ShopSphere.OrderService.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ShopSphere.OrderService.Application.Interfaces
{
  public interface IOrderService
  {
    Guid CreateOrder(OrderDto orderDto);
    OrderDto GetOrderById(Guid orderId);
    void UpdateOrder(OrderDto orderDto);
    void DeleteOrder(Guid orderId);
  }
}
