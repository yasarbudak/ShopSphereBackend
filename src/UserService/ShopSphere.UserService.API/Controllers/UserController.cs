using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using ShopSphere.UserService.API.Services;
using ShopSphere.UserService.Application.DTOs;
using ShopSphere.UserService.Application.Interfaces;

namespace ShopSphere.UserService.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UserController : ControllerBase
  {
    private readonly IUserService _userService;
    private readonly ITokenService _tokenService;

    public UserController(IUserService userService, ITokenService tokenService)
    {
      _userService = userService;
      _tokenService = tokenService;
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

    // Admin rolüne sahip kullanıcılar için
    [Authorize(Roles = "Admin")]
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

    // Giriş yapmış kullanıcılar tarafından kullanılabilir
    [Authorize]
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

    // Giriş yapmadan herkesin erişebileceği endpoint
    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequest)
    {
      if (string.IsNullOrWhiteSpace(loginRequest.Password))
      {
        return BadRequest("Password is required.");
      }

      var user = !string.IsNullOrWhiteSpace(loginRequest.Username)
          ? await _userService.GetUserByUsernameAsync(loginRequest.Username)
          : await _userService.GetUserByEmailAsync(loginRequest.Email);

      if (user == null)
      {
        return Unauthorized("Invalid username or email.");
      }

      // Şifre doğrulaması (örnek)
      if (!VerifyPasswordHash(loginRequest.Password, user.PasswordHash))
      {
        return Unauthorized("Invalid password.");
      }

      // JWT token üretimi gibi işlemler
      return Ok("Login successful.");
    }

    private bool VerifyPasswordHash(string password, string storedHash)
    {
      // Şifre doğrulama için uygun bir yöntem (örneğin, BCrypt kullanabilirsiniz)
      return BCrypt.Net.BCrypt.Verify(password, storedHash);
    }
  }
}
