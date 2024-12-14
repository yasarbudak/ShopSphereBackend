using Microsoft.EntityFrameworkCore;
using Moq;
using ShopSphere.OrderService.Domain.Entities;
using ShopSphere.OrderService.Domain.Enums;
using ShopSphere.OrderService.Persistence.DbContexts;
using ShopSphere.OrderService.Persistence.Repositories;
using Xunit;

public class OrderRepositoryTests
{
  private readonly Mock<OrderDbContext> _mockContext;
  private readonly Mock<DbSet<Order>> _mockSet;
  private readonly OrderRepository _repository;

  public OrderRepositoryTests()
  {
    _mockContext = new Mock<OrderDbContext>();
    _mockSet = new Mock<DbSet<Order>>();

    _mockContext.Setup(c => c.Orders).Returns(_mockSet.Object);
    _repository = new OrderRepository(_mockContext.Object);
  }

  [Fact]
  public void CreateOrder_ShouldReturnNewGuid_WhenOrderIsAdded()
  {
    // Arrange
    var order = new Order
    {
      OrderId = Guid.NewGuid(),
      OrderDate = DateTime.UtcNow,
      CustomerId = Guid.NewGuid(),
      Status = OrderStatus.Pending,
      TotalAmount = 100m
    };

    _mockSet.Setup(m => m.Add(It.IsAny<Order>())).Callback<Order>(o => o.OrderId = order.OrderId);

    // Act
    var result = _repository.CreateOrder(order);

    // Assert
    Assert.NotEqual(Guid.Empty, result);
    _mockSet.Verify(m => m.Add(It.IsAny<Order>()), Times.Once());
    _mockContext.Verify(m => m.SaveChanges(), Times.Once());
  }

  [Fact]
  public void GetOrderById_ShouldReturnOrder_WhenOrderExists()
  {
    // Arrange
    var orderId = Guid.NewGuid();
    var order = new Order
    {
      OrderId = orderId,
      OrderDate = DateTime.UtcNow,
      CustomerId = Guid.NewGuid(),
      Status = OrderStatus.Pending,
      TotalAmount = 150m
    };

    _mockSet.Setup(m => m.Find(orderId)).Returns(order);
    _mockContext.Setup(c => c.Orders).Returns(_mockSet.Object);

    // Act
    var result = _repository.GetOrderById(orderId);

    // Assert
    Assert.NotNull(result);
    Assert.Equal(orderId, result.OrderId);
  }

  [Fact]
  public void UpdateOrder_ShouldCallUpdateAndSaveChanges_WhenOrderIsUpdated()
  {
    // Arrange
    var order = new Order
    {
      OrderId = Guid.NewGuid(),
      OrderDate = DateTime.UtcNow,
      CustomerId = Guid.NewGuid(),
      Status = OrderStatus.Pending,
      TotalAmount = 200m
    };

    _mockSet.Setup(m => m.Update(order));
    _mockContext.Setup(c => c.Orders).Returns(_mockSet.Object);

    // Act
    _repository.UpdateOrder(order);

    // Assert
    _mockSet.Verify(m => m.Update(It.IsAny<Order>()), Times.Once());
    _mockContext.Verify(m => m.SaveChanges(), Times.Once());
  }

  [Fact]
  public void DeleteOrder_ShouldRemoveOrder_WhenOrderExists()
  {
    // Arrange
    var orderId = Guid.NewGuid();
    var order = new Order
    {
      OrderId = orderId
    };

    _mockSet.Setup(m => m.Find(orderId)).Returns(order);
    _mockSet.Setup(m => m.Remove(order));
    _mockContext.Setup(c => c.Orders).Returns(_mockSet.Object);

    // Act
    _repository.DeleteOrder(orderId);

    // Assert
    _mockSet.Verify(m => m.Remove(It.IsAny<Order>()), Times.Once());
    _mockContext.Verify(m => m.SaveChanges(), Times.Once());
  }
}
