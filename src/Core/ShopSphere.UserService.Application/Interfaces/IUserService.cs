using ShopSphere.UserService.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSphere.UserService.Application.Interfaces
{
  public interface IUserService
  {
    Task<UserDto> GetUserByIdAsync(Guid userId);
    Task<bool> CreateUserAsync(CreateUserDto user);
    Task<bool> UpdateUserAsync(UpdateUserDto user);
    Task<bool> DeleteUserAsync(Guid userId);
  }
}
