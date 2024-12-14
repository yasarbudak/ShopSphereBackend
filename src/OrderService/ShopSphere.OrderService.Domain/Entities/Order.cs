using ShopSphere.OrderService.Domain.Enums;

namespace ShopSphere.OrderService.Domain.Entities
{
  public class Order
  {
        public Guid OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public Guid CustomerId { get; set; }
        public OrderStatus Status{ get; set; }
        public decimal TotalAmount { get; set; }
    }
}
