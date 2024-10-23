using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSphere.UserService.Infrastructure.Logging
{
  public interface ILoggingService
  {
    void LogInfo(string message, Exception ex);
    void LogError(string message);
  }
}
