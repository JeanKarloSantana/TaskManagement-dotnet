using Microsoft.AspNetCore.Mvc;
using TaskManagement.Application.Services;
using TaskManagement.Contracts.Tasks;

namespace TaskManagement.API.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class TasksController(ITasksService tasksService) : ControllerBase
  {
    [HttpPost]
    public IActionResult CreateTask(CreateTaskRequest request)
    {
      var taskId = tasksService.CreateTask(request.userId, request.title, request.description, request.dueDate, request.priority, request.status);
      return Ok(taskId);
    }
  }
}