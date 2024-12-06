using ShopSphere.OrderService.Domain.Entities;
using ShopSphere.OrderService.Domain.Interfaces;
using ShopSphere.OrderService.Persistence.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSphere.OrderService.Persistence.Repositories
{
  public class OrderRepository : IOrderRepository
  {
    private readonly OrderDbContext _orderDbContext;
    public OrderRepository(OrderDbContext orderDbContext)
    {
      _orderDbContext = orderDbContext;
    }

    public Guid CreateOrder(Order order)
    {
      _orderDbContext.Orders.Add(order);
      _orderDbContext.SaveChanges();
      return Guid.NewGuid();
    }

    public void DeleteOrder(Guid orderId)
    {
      var order = _orderDbContext.Orders.Find(orderId);
      if (order != null)
      {
        _orderDbContext.Orders.Remove(order);
        _orderDbContext.SaveChanges();
      }
    }

    public Order GetOrderById(Guid orderId)
    {
      return _orderDbContext.Orders.Find(orderId);
    }

    public void UpdateOrder(Order order)
    {
      _orderDbContext.Orders.Update(order);
      _orderDbContext.SaveChanges();
    }
  }
}
