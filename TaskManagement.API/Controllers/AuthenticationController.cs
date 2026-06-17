using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Application.ApplicationUsers.Commands;
using TaskManagement.Contracts.ApplicationUser;


namespace TaskManagement.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SingUpController(IDependencyMediator mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult> CreateUser(CreateUserRequest request)
        {
            var command = new CreateUserCommand(request.UserName, request.Email, request.Password);
            var createUserResult = await mediator.Send(command);
            return createUserResult.MatchFirst(user => Ok(user),
            error => Problem(error.Code));
        }
    }
}