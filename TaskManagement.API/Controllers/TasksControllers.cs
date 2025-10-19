using Microsoft.AspNetCore.Mvc;
using TaskManagement.Application.Services;
using TaskManagement.Contracts.Tasks;

namespace TaskManagement.API.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class TasksController(ICustomMediator mediator) : ControllerBase
  {
    [HttpPost]
    //public async Task<IActionResult> CreateTask(CreateTaskRequest request)
     public async Task<ActionResult<User>> GetUser(int id)
    {
      //var taskId = tasksService.CreateTask(request.userId, request.title, request.description, request.dueDate, request.priority, request.status);
      var query = new GetUserQuery { UserId = id };
      var user = await mediator.Send(query);
      return Ok(user);
      //return Ok(taskId);
    }
  }
}