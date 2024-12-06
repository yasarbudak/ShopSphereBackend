using Microsoft.EntityFrameworkCore;
using ShopSphere.UserService.Domain.Entities;
using ShopSphere.UserService.Domain.Interfaces;
using ShopSphere.UserService.Persistence.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSphere.UserService.Persistence.Repositories
{
  public class UserRepository : IUserRepository
  {
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context)
    {
      _context = context;
    }

    public async Task<User> GetUserByIdAsync(Guid userId)
    {
      return await _context.Users.FindAsync(userId);
    }

    public async Task<List<User>> GetAllUsersAsync()
    {
      return await _context.Users.ToListAsync();
    }

    public async Task<bool> AddUserAsync(User user)
    {
      await _context.Users.AddAsync(user);
      var result = await _context.SaveChangesAsync();
      return result > 0; // If SaveChangesAsync returns > 0, it means changes were successfully saved
    }

    public async Task<bool> UpdateUserAsync(User user)
    {
      _context.Users.Update(user);
      var result = await _context.SaveChangesAsync();
      return result > 0;
    }

    public async Task<bool> DeleteUserAsync(Guid userId)
    {
      try
      {
        var user = await _context.Users.FindAsync(userId);
        if (user == null)
        {
          return false; // Return false if user is not found
        }

        _context.Users.Remove(user);
        await _context.SaveChangesAsync();

        return true; // Return true if deletion is successful
      }
      catch
      {
        return false; // Return false if an exception occurs
      }
    }

    public async Task<User?> GetUserByUsernameAsync(string username)
    {
      return await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
    }

    public async Task<User?> GetUserByEmailAsync(string email)
    {
      return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
    }
  }
}
