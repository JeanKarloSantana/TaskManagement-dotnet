using ErrorOr;
using Microsoft.AspNetCore.Identity;
using TaskManagement.Application.Services.JwtGenerator;
using TaskManagement.Domain.ApplicationUsers;

namespace TaskManagement.Application.ApplicationUsers.Commands
{
  public sealed class LoginUserCommandHandler(
    UserManager<ApplicationUser> userManager,
    IJwtGenerator jwtGenerator)
    : IRequestHandler<LoginUserCommand, ErrorOr<JwtTokenResult>>
  {
    public async Task<ErrorOr<JwtTokenResult>> Handle(
      LoginUserCommand request,
      CancellationToken cancellationToken)
    {
      var user = await userManager.FindByEmailAsync(request.Email);

      if (user is null)
      {
        return InvalidCredentials();
      }

      if (await userManager.IsLockedOutAsync(user))
      {
        return InvalidCredentials();
      }

      var passwordIsValid = await userManager.CheckPasswordAsync(
        user,
        request.Password);

      if (!passwordIsValid)
      {
        await userManager.AccessFailedAsync(user);
        return InvalidCredentials();
      }

      await userManager.ResetAccessFailedCountAsync(user);

      var roles = await userManager.GetRolesAsync(user);

      return jwtGenerator.GenerateToken(user, roles.ToArray());
    }

    private static Error InvalidCredentials()
    {
      return Error.Unauthorized(
        code: "Authentication.InvalidCredentials",
        description: "Invalid email or password.");
    }
  }
}
