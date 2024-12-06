using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSphere.UserService.Application.DTOs
{
  public class UserDto
  {
    public Guid UserId { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }
    public DateTime? LastLogin { get; set; }
    public string PasswordHash { get; set; }
  }
}
