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
        UserId = Guid.NewGuid(),
        Username = user.Username,
        Email = user.Email
      };
      return await _userRepository.AddUserAsync(userEntity);
    }

    public async Task<bool> UpdateUserAsync(UserDto user)
    {
      var userEntity = new User
      {
        UserId = user.UserId,
        Username = user.Username,
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
        UserId = user.UserId,
        Username = user.Username,
        Email = user.Email,
        LastLogin = user.LastLogin,
        Role = user.Role,
      };
    }

    public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
    {
      var users = await _userRepository.GetAllUsersAsync();
      return users.Select(user => new UserDto
      {
        UserId = user.UserId,
        Username = user.Username,
        Email = user.Email,
        LastLogin = user.LastLogin,
        Role = user.Role,
      });
    }
    public async Task<UserDto> GetUserByUsernameAsync(string username)
    {
      // Repository'den veriyi al
      var user = await _userRepository.GetUserByUsernameAsync(username);
      if (user == null)
      {
        return null; // Kullanıcı bulunamadı
      }

      // İş mantığını uygula ve DTO'ya dönüştür
      return new UserDto
      {
        UserId = user.UserId,
        Username = user.Username,
        Email = user.Email,
        Role = user.Role,
        LastLogin = user.LastLogin
      };
    }

    public async Task<UserDto?> GetUserByEmailAsync(string email)
    {
      // Repository'den veriyi al
      var user = await _userRepository.GetUserByEmailAsync(email);
      if (user == null)
      {
        return null; // Kullanıcı bulunamadı
      }

      // İş mantığını uygula ve DTO'ya dönüştür
      return new UserDto
      {
        UserId = user.UserId,
        Username = user.Username,
        Email = user.Email,
        Role = user.Role,
        LastLogin = user.LastLogin
      };
    }
  }
}
