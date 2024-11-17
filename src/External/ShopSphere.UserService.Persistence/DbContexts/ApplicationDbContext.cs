using Microsoft.EntityFrameworkCore;
using ShopSphere.UserService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSphere.UserService.Persistence.DbContexts
{
  public class ApplicationDbContext : DbContext
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions) : base(dbContextOptions) { }

    public DbSet<User> Users { get; set; }
    //public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      //Fluent API configuration for user entity.
      modelBuilder.Entity<User>()
        .HasKey(u=>u.UserId); // primary Key
    }
  }
}
