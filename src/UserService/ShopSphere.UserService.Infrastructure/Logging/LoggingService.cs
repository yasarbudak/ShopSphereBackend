using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSphere.UserService.Infrastructure.Logging
{
  public class LoggingService : ILoggingService
  {
    public void LogError(string message)
    {
      Console.WriteLine($"Info: {message}");
    }

    public void LogInfo(string message, Exception ex)
    {
      Console.WriteLine($"Error: {message}, Exception: {ex.Message}");
    }
  }
}
