using ShopSphere.UserService.Application.DTOs;
using ShopSphere.UserService.Application.Interfaces;
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

    public Task<bool> CreateUserAsync(CreateUserDto user)
    {
      throw new NotImplementedException();
    }

    public Task<bool> DeleteUserAsync(Guid userId)
    {
      throw new NotImplementedException();
    }

    public Task<UserDto> GetUserByIdAsync(Guid userId)
    {
      throw new NotImplementedException();
    }

    public Task<bool> UpdateUserAsync(UpdateUserDto user)
    {
      throw new NotImplementedException();
    }
  }
}
