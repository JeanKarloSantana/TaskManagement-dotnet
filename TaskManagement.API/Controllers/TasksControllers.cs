using Microsoft.AspNetCore.Mvc;
using TaskManagement.Application.Services;
using TaskManagement.Application.Tasks.Commands.CreateTask;
using TaskManagement.Contracts.Tasks;

namespace TaskManagement.API.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class TasksController(IDependencyMediator mediator) : ControllerBase
  {
    [HttpPost]
    public async Task<ActionResult> CreateTask([FromQuery] Guid userId, [FromQuery] string title, [FromQuery] string description, [FromQuery] DateTime dueDate, [FromQuery] string priority, [FromQuery] string status)
    {
      var command = new CreateTaskCommand(userId, title, description, dueDate, priority, status);
      Console.WriteLine("Sending CreateTaskCommand...");
      var createTaskResult = await mediator.Send(command);

      return createTaskResult.MatchFirst(guid => Ok(new CreateTaskResponse(guid)),
      error => Problem());
    }
  }
}