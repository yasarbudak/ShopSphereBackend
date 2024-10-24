using ShopSphere.UserService.Application.DTOs;
using ShopSphere.UserService.Application.Interfaces;
using ShopSphere.UserService.Domain.Entities;
using ShopSphere.UserService.Domain.Interfaces;

namespace ShopSphere.UserService.Application.Services
{
  public class UserServiceImplementation : IUserService
  {
    private readonly IUserRepository _userRepository;
    public UserServiceImplementation(IUserRepository userRepository)
    {
      _userRepository = userRepository;
    }

    public async Task<bool> AddUserAsync(UserDto user)
    {
      var userEntity = new User
      {
        Id = Guid.NewGuid(),
        Name = user.Name,
        Email = user.Email
      };
      return await _userRepository.AddUserAsync(userEntity);
    }

    public async Task<bool> UpdateUserAsync(UserDto user)
    {
      var userEntity = new User
      {
        Id = user.Id,
        Name = user.Name,
        Email = user.Email
      };
      return await _userRepository.UpdateUserAsync(userEntity);
    }

    public async Task<bool> DeleteUserAsync(Guid userId)
    {
      return await _userRepository.DeleteUserAsync(userId);
    }

    public async Task<UserDto> GetUserByIdAsync(Guid userId)
    {
      var user = await _userRepository.GetUserByIdAsync(userId);
      if (user == null) return null;

      return new UserDto
      {
        Id = user.Id,
        Name = user.Name,
        Email = user.Email
      };
    }

    public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
    {
      var users = await _userRepository.GetAllUsersAsync();
      return users.Select(user => new UserDto
      {
        Id = user.Id,
        Name = user.Name,
        Email = user.Email
      });
    }
  }
}
