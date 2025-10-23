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
    //public async Task<IActionResult> CreateTask(CreateTaskRequest request)
    public async Task<ActionResult<User>> GetUser(Guid userId, string title, string description, DateTime dueDate, string priority, string status)
    {
      var command = new CreateTaskCommand(userId, title, description, dueDate, priority, status);

      var createTaskResult = await mediator.Send(command);

      if (createTaskResult.IsError)
      {
        return Problem();
      }

      var response = new CreateTaskResponse(createTaskResult.Value);

      return Ok(response);
    }
  }
}