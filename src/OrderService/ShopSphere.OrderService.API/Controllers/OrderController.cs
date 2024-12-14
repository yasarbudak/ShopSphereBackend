using Microsoft.AspNetCore.Mvc;
using ShopSphere.OrderService.Application.DTOs;
using ShopSphere.OrderService.Application.Interfaces;
using ShopSphere.OrderService.Domain.Entities;

[ApiController]
[Route("api/orders")]
public class OrderController : ControllerBase
{
  private readonly IOrderService _orderService;

  public OrderController(IOrderService orderService)
  {
    _orderService = orderService;
  }

  [HttpPost]
  public IActionResult CreateOrder([FromBody] OrderDto order)
  {
    var orderId = _orderService.CreateOrder(order);
    return Ok(orderId);
  }

  [HttpGet("{orderId}")]
  public IActionResult GetOrderById(Guid orderId)
  {
    var order = _orderService.GetOrderById(orderId);
    if (order == null)
    {
      return NotFound();
    }
    return Ok(order);
  }

  [HttpPut]
  public IActionResult UpdateOrder([FromBody] OrderDto order)
  {
    _orderService.UpdateOrder(order);
    return NoContent();
  }

  [HttpDelete("{orderId}")]
  public IActionResult DeleteOrder(Guid orderId)
  {
    _orderService.DeleteOrder(orderId);
    return NoContent();
  }
}
