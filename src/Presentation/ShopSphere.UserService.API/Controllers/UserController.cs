using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopSphere.UserService.Application.DTOs;
using ShopSphere.UserService.Application.Interfaces;

namespace ShopSphere.UserService.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UserController : ControllerBase
  {
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
      _userService = userService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser(UserDto user)
    {
      var result = await _userService.AddUserAsync(user);
      if (result)
      {
        return Ok("User created successfully.");
      }
      return BadRequest("User creation failed.");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateUser(UserDto user)
    {
      var result = await _userService.UpdateUserAsync(user);
      if (result)
      {
        return Ok("User updated successfully.");
      }
      return BadRequest("User update failed.");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(Guid id)
    {
      var result = await _userService.DeleteUserAsync(id);
      if (result)
      {
        return Ok("User deleted successfully.");
      }
      return BadRequest("User deletion failed.");
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById(Guid id)
    {
      var user = await _userService.GetUserByIdAsync(id);
      if (user == null)
      {
        return NotFound("User not found.");
      }
      return Ok(user);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
      var users = await _userService.GetAllUsersAsync();
      return Ok(users);
    }
  }
}
