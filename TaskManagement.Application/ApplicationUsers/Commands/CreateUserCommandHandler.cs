using ErrorOr;
using Microsoft.AspNetCore.Identity;
using TaskManagement.Domain.ApplicationUsers;

namespace TaskManagement.Application.ApplicationUsers.Commands

{
  public class CreateApplicationUserCommandHandler(UserManager<ApplicationUser> userManager) : IRequestHandler<CreateUserCommand, ErrorOr<bool>>
  {

    private readonly UserManager<ApplicationUser> _userManager = userManager;

    public async Task<ErrorOr<bool>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
      var user = new ApplicationUser
      {
        UserName = request.UserName,
        Email = request.Email,
        PasswordHash = request.Password
      };

      var result = await _userManager.CreateAsync(user, request.Password);

      if (!result.Succeeded)
      {
        return result.Errors
          .Select(e => Error.Failure(code: e.Code, description: e.Description))
          .ToList();
      }

      return result.Succeeded;
    }
  }
}
