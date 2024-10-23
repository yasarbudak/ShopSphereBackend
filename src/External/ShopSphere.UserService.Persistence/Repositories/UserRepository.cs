using ShopSphere.UserService.Domain.Entities;
using ShopSphere.UserService.Domain.Interfaces;
using ShopSphere.UserService.Persistence.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSphere.UserService.Persistence.Repositories
{
  public class UserRepository : IUserRepository
  {
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context)
    {
      _context = context;
    }

    public Task<bool> AddAsync(User user)
    {
      throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(Guid userId)
    {
      throw new NotImplementedException();
    }

    public Task<User> GetUserByIdAsync(Guid userId)
    {
      throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(User user)
    {
      throw new NotImplementedException();
    }
  }
}
