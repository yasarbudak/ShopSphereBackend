using BCrypt.Net;
using Microsoft.EntityFrameworkCore;
using ShopSphere.UserService.Domain.Entities;
using ShopSphere.UserService.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSphere.UserService.Persistence.DbContexts
{
  public class UserServiceDbContext : DbContext
  {
    public UserServiceDbContext(DbContextOptions<UserServiceDbContext> dbContextOptions) : base(dbContextOptions) { }

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      //Fluent API configuration for user entity.
      modelBuilder.Entity<User>()
        .HasKey(u => u.UserId); // primary Key

      // Fluent API ile Unique Constraint ekleniyor
      modelBuilder.Entity<User>()
          .HasIndex(u => u.Username)
          .IsUnique();

      // Örnek kullanıcılar
      modelBuilder.Entity<User>().HasData(
          new User
          {
            UserId = Guid.NewGuid(),
            Username = "admin",
            Email = "admin@example.com",
            PasswordHash = BCrypt.Net.BCrypt.HashPassword("Admin123!"), // Şifreyi hashliyoruz
            Role = Role.Admin,
            CreatedAt = DateTime.UtcNow
          },
          new User
          {
            UserId = Guid.NewGuid(),
            Username = "user",
            Email = "user@example.com",
            PasswordHash = BCrypt.Net.BCrypt.HashPassword("User123!"), // Şifreyi hashliyoruz
            Role = Role.User,
            CreatedAt = DateTime.UtcNow
          }
      );
    }
  }
}
