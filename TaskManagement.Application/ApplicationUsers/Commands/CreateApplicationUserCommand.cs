using ErrorOr;
using TaskManagement.Domain.ApplicationUsers;

namespace TaskManagement.Application.ApplicationUsers.Commands
{
  public record CreateApplicationUserCommand(string Username, string Email, bool EmailConfirmed, string Password) : IRequest<ErrorOr<ApplicationUser>>;
}