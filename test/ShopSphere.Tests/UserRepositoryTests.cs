using Xunit;
using Moq;
using Microsoft.EntityFrameworkCore;
using ShopSphere.UserService.Domain.Entities;
using ShopSphere.UserService.Persistence.Repositories;
using ShopSphere.UserService.Persistence.DbContexts;
using System;
using System.Threading.Tasks;

namespace ShopSphere.Tests
{
  public class UserRepositoryTests
  {
    private readonly UserRepository _userRepository;
    private readonly ApplicationDbContext _applicationDbContext;

    public UserRepositoryTests()
    {
      var options = new DbContextOptionsBuilder<ApplicationDbContext>()
        .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
        .Options;
      _applicationDbContext = new ApplicationDbContext(options);
      _userRepository = new UserRepository(_applicationDbContext);
    }

    [Fact]
    public async Task AddUserAsync_ShouldReturnTrue_WhenUserIsAddedSuccessfully()
    {
      //Arrange
      var user = new User { Id = Guid.NewGuid(), Name = "John Doe", Email = "john.doe@example.com" };

      //Act
      var result = await _userRepository.AddUserAsync(user);

      //Assert
      Assert.True(result);
      Assert.Contains(_applicationDbContext.Users, u => u.Id == user.Id);
    }

    [Fact]
    public async Task UpdateUserAsync_ShouldReturnTrue_WhenUserIsUpdateSuccessfully()
    {
      //Arrange
      var user = new User { Id = Guid.NewGuid(), Name = "John Doe", Email = "john.doe@example.com" };
      await _userRepository.UpdateUserAsync(user);

      user.Name = "Freddie Mercury";

      //Act
      var result = await _userRepository.UpdateUserAsync(user);

      //Assert
      Assert.True(result);
      Assert.Equal("Freddie Mercury", _applicationDbContext.Users.Find(user.Id).Name);
    }

    [Fact]
    public async Task DeleteUserAsync_ShouldReturnTrue_WhenUserIsDeleteSuccessfully()
    {
      //Arrange
      var user = new User { Id = Guid.NewGuid(), Name = "John Doe", Email = "john.doe@example.com" };
      await _userRepository.AddUserAsync(user);

      //Act
      var result = await _userRepository.DeleteUserAsync(user.Id);

      //Assert
      Assert.True(result);
      Assert.DoesNotContain(_applicationDbContext.Users, u => u.Id == user.Id);
    }
  }
}
