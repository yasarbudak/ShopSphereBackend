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
    Task<User?> GetUserByUsernameAsync(string name);
    Task<User?> GetUserByEmailAsync(string email);
    Task<List<User>> GetAllUsersAsync();
    Task<bool> AddUserAsync(User user);
    Task<bool> UpdateUserAsync(User user);
    Task<bool> DeleteUserAsync(Guid userId);
  }
}
