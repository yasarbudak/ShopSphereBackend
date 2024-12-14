using ShopSphere.OrderService.Application.DTOs;

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
