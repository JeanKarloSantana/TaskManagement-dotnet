using ErrorOr;
using TaskManagement.Application.Services.JwtGenerator;

namespace TaskManagement.Application.ApplicationUsers.Commands
{
  public sealed record LoginUserCommand(
    string Email,
    string Password) : IRequest<ErrorOr<JwtTokenResult>>;
}
