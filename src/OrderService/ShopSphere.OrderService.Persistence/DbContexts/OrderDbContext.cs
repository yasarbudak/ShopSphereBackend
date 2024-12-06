using Microsoft.EntityFrameworkCore;
using ShopSphere.OrderService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSphere.OrderService.Persistence.DbContexts
{
  public class OrderDbContext : DbContext
  {
    public OrderDbContext(DbContextOptions<OrderDbContext> dbContextOptions) : base(dbContextOptions) { }

    public DbSet<Order> Orders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);
    }
  }
}
