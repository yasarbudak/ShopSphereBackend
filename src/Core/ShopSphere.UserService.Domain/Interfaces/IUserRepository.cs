using ShopSphere.UserService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSphere.UserService.Domain.Interfaces
{
  public interface IUserRepository
  {
    Task<User> GetUserByIdAsync(Guid userId);
    Task<bool> AddAsync(User user);
    Task<bool> UpdateAsync(User user);
    Task<bool> DeleteAsync(Guid userId);
  }
}
