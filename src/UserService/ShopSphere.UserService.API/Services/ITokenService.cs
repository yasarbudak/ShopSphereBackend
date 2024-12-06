namespace ShopSphere.UserService.API.Services
{
  public interface ITokenService
  {
    string GenerateToken(string userId, string role);
  }
}
