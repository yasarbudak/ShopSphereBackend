using Microsoft.EntityFrameworkCore;
using ShopSphere.ProductService.Domain.Entities;

namespace ShopSphere.ProductService.Persistence.DbContexts
{
  public class ProductDbContext : DbContext
  {
    public ProductDbContext(DbContextOptions<ProductDbContext> dbContextOptions) : base (dbContextOptions) { }
    
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder); 
    }
  }
}
