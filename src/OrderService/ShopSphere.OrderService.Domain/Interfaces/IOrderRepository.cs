using ShopSphere.OrderService.Domain.Entities;


namespace ShopSphere.OrderService.Domain.Interfaces
{
  public interface IOrderRepository
  {
    Guid CreateOrder(Order order);
    Order GetOrderById(Guid orderId);
    void UpdateOrder(Order order);
    void DeleteOrder(Guid orderId);
  }
}
