using ShopSphere.OrderService.Application.DTOs;
using ShopSphere.OrderService.Application.Interfaces;
using ShopSphere.OrderService.Domain.Entities;
using ShopSphere.OrderService.Domain.Interfaces;

namespace ShopSphere.OrderService.Application.Services
{
  public class OrderServiceImplementation : IOrderService
  {
    private readonly IOrderRepository _orderRepository;

    public OrderServiceImplementation(IOrderRepository orderRepository)
    {
      _orderRepository = orderRepository;
    }
    public Guid CreateOrder(OrderDto orderDto)
    {
      var order = new Order
      {
        OrderId = Guid.NewGuid(),
        OrderDate = orderDto.OrderDate,
        CustomerId = orderDto.CustomerId,
        Status = orderDto.Status,
        TotalAmount = orderDto.TotalAmount,
      };

      return _orderRepository.CreateOrder(order);
    }

    public void DeleteOrder(Guid orderId)
    {
      _orderRepository.DeleteOrder(orderId);
    }

    public OrderDto GetOrderById(Guid orderId)
    {
      var order = _orderRepository.GetOrderById(orderId);
      if (order == null) return null!;

      return new OrderDto
      {
        OrderId = order.OrderId,
        OrderDate = order.OrderDate,
        CustomerId = order.CustomerId,
        Status = order.Status,
        TotalAmount = order.TotalAmount
      };
    }

    public void UpdateOrder(OrderDto orderDto)
    {
      var order = new Order
      {
        OrderId = orderDto.OrderId,
        OrderDate = orderDto.OrderDate,
        CustomerId = orderDto.CustomerId,
        Status = orderDto.Status,
        TotalAmount = orderDto.TotalAmount
      };

      _orderRepository.UpdateOrder(order);
    }
  }
}
