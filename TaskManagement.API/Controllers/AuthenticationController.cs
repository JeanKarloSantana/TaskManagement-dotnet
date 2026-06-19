using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Application.ApplicationUsers.Commands;
using TaskManagement.Contracts.ApplicationUser;

namespace TaskManagement.API.Controllers
{
  [ApiController]
  [Route("api/auth")]
  public sealed class AuthenticationController(IDependencyMediator mediator) : ControllerBase
  {
    [AllowAnonymous]
    [HttpPost("signup")]
    public async Task<ActionResult> CreateUser(
      CreateUserRequest request,
      CancellationToken cancellationToken)
    {
      var command = new CreateUserCommand(
        request.UserName,
        request.Email,
        request.Password);

      var result = await mediator.Send(command, cancellationToken);

      return result.MatchFirst<ActionResult>(
        _ => StatusCode(StatusCodes.Status201Created),
        error => Problem(
          statusCode: StatusCodes.Status400BadRequest,
          detail: error.Description));
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<ActionResult<LoginUserResponse>> Login(
      LoginUserRequest request,
      CancellationToken cancellationToken)
    {
      var command = new LoginUserCommand(request.Email, request.Password);
      var result = await mediator.Send(command, cancellationToken);

      return result.MatchFirst<ActionResult<LoginUserResponse>>(
        token => Ok(new LoginUserResponse(
          token.AccessToken,
          token.ExpiresAtUtc)),
        error => Problem(
          statusCode: StatusCodes.Status401Unauthorized,
          detail: error.Description));
    }
  }
}
