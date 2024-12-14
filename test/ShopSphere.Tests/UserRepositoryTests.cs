using Microsoft.EntityFrameworkCore;
using ShopSphere.UserService.Domain.Entities;
using ShopSphere.UserService.Persistence.DbContexts;
using ShopSphere.UserService.Persistence.Repositories;

namespace ShopSphere.Tests
{
  public class UserRepositoryTests
  {
    private readonly UserRepository _userRepository;
    private readonly UserServiceDbContext _UserServiceDbContext;

    public UserRepositoryTests()
    {
      var options = new DbContextOptionsBuilder<UserServiceDbContext>()
        .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
        .Options;
      _UserServiceDbContext = new UserServiceDbContext(options);
      _userRepository = new UserRepository(_UserServiceDbContext);
    }

    [Fact]
    public async Task AddUserAsync_ShouldReturnTrue_WhenUserIsAddedSuccessfully()
    {
      //Arrange
      var user = new User { UserId = Guid.NewGuid(), Username = "John Doe", Email = "john.doe@example.com" };

      //Act
      var result = await _userRepository.AddUserAsync(user); 

      //Assert
      Assert.True(result);
      Assert.Contains(_UserServiceDbContext.Users, u => u.UserId == user.UserId);
    }

    [Fact]
    public async Task UpdateUserAsync_ShouldReturnTrue_WhenUserIsUpdateSuccessfully()
    {
      //Arrange
      var user = new User { UserId = Guid.NewGuid(), Username = "John Doe", Email = "john.doe@example.com" };
      await _userRepository.UpdateUserAsync(user);

      user.Username = "Freddie Mercury";

      //Act
      var result = await _userRepository.UpdateUserAsync(user);

      //Assert
      Assert.True(result);
      Assert.Equal("Freddie Mercury", _UserServiceDbContext.Users.Find(user.UserId).Username);
    }

    [Fact]
    public async Task DeleteUserAsync_ShouldReturnTrue_WhenUserIsDeleteSuccessfully()
    {
      //Arrange
      var user = new User { UserId = Guid.NewGuid(), Username = "John Doe", Email = "john.doe@example.com" };
      await _userRepository.AddUserAsync(user);

      //Act
      var result = await _userRepository.DeleteUserAsync(user.UserId);

      //Assert
      Assert.True(result);
      Assert.DoesNotContain(_UserServiceDbContext.Users, u => u.UserId == user.UserId);
    }
  }
}
