using Microsoft.AspNetCore.Mvc;
using TaskManagement.Application.Services;
using TaskManagement.Application.WorkItems.Commands.CreateWorkItem;
using TaskManagement.Contracts.WorkItems;

namespace TaskManagement.API.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class WorkItemsController(IDependencyMediator mediator) : ControllerBase
  {
    [HttpPost]
    public async Task<ActionResult> CreateWorkItem(CreateWorkItemRequest request)
    {
      var command = new CreateWorkItemCommand(request.UserId, request.Title, request.Description, request.DueDate, request.Priority, request.Status);

      var createWorkItemResult = await mediator.Send(command);

      return createWorkItemResult.MatchFirst(workItem => Ok(new CreateWorkItemResponse(workItem.UserId, workItem.Title, workItem.Description, workItem.DueDate, workItem.Priority, workItem.Status)),
      error => Problem());
    }
  }
}