using Microsoft.EntityFrameworkCore;
using ShopSphere.OrderService.Domain.Entities;

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
