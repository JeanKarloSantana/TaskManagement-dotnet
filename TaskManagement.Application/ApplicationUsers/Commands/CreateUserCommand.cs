using ErrorOr;
using TaskManagement.Domain.ApplicationUsers;

namespace TaskManagement.Application.ApplicationUsers.Commands
{
  public record CreateUserCommand(string UserName, string Email, string Password) : IRequest<ErrorOr<bool>>;
}