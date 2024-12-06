using ShopSphere.OrderService.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
