using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using TaskManagement.Application.Services.JwtGenerator;
using TaskManagement.Domain.ApplicationUsers;

namespace TaskManagement.Infrastructure.Authentication
{
  public sealed class JwtGenerator(
    JwtSettings settings,
    TimeProvider timeProvider) : IJwtGenerator
  {
    public JwtTokenResult GenerateToken(
      ApplicationUser user,
      IReadOnlyCollection<string> roles)
    {
      var now = timeProvider.GetUtcNow().UtcDateTime;
      var expiresAt = now.AddMinutes(settings.ExpirationMinutes);

      var claims = new List<Claim>
      {
        new(JwtRegisteredClaimNames.Sub, user.Id),
        new(ClaimTypes.NameIdentifier, user.Id),
        new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
      };

      if (!string.IsNullOrWhiteSpace(user.UserName))
      {
        claims.Add(new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName));
      }

      if (!string.IsNullOrWhiteSpace(user.Email))
      {
        claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
      }

      claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

      var securityKey = new SymmetricSecurityKey(
        Encoding.UTF8.GetBytes(settings.Secret));

      var signingCredentials = new SigningCredentials(
        securityKey,
        SecurityAlgorithms.HmacSha256);

      var token = new JwtSecurityToken(
        issuer: settings.Issuer,
        audience: settings.Audience,
        claims: claims,
        notBefore: now,
        expires: expiresAt,
        signingCredentials: signingCredentials);

      var accessToken = new JwtSecurityTokenHandler().WriteToken(token);

      return new JwtTokenResult(accessToken, expiresAt);
    }
  }
}
