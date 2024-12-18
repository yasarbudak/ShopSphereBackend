﻿using ShopSphere.UserService.Application.DTOs;
using ShopSphere.UserService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSphere.UserService.Application.Interfaces
{
  public interface IUserService
  {
    Task<bool> AddUserAsync(UserDto user);
    Task<bool> UpdateUserAsync(UserDto user);
    Task<bool> DeleteUserAsync(Guid userId);
    Task<UserDto> GetUserByIdAsync(Guid userId);
    Task<IEnumerable<UserDto>> GetAllUsersAsync();
    Task<UserDto> GetUserByUsernameAsync(string username);
    Task<UserDto> GetUserByEmailAsync(string email);
  }
}
