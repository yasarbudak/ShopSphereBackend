﻿using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ShopSphere.UserService.API.Services
{
  public class TokenService : ITokenService
  {
    private readonly IConfiguration _configuration;

    public TokenService(IConfiguration configuration)
    {
      _configuration = configuration;
    }

    public string GenerateToken(string userId, string role)
    {
      var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
      var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

      var claims = new[]
      {
        new Claim(JwtRegisteredClaimNames.Sub, userId),
        new Claim(ClaimTypes.Role, role),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
      };

      var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(double.Parse(_configuration["Jwt:ExpiresInMinutes"])),
                signingCredentials: creds
            );

      return new JwtSecurityTokenHandler().WriteToken(token);
    }
  }
}
