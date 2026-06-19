using TaskManagement.Domain.ApplicationUsers;

namespace TaskManagement.Application.Services.JwtGenerator
{
    public interface IJwtGenerator
    {
        JwtTokenResult GenerateToken(
            ApplicationUser user,
            IReadOnlyCollection<string> roles);
    }

    public sealed record JwtTokenResult(
        string AccessToken,
        DateTime ExpiresAtUtc);
}
