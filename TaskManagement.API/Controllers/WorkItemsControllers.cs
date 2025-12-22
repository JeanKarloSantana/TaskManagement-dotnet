using Microsoft.AspNetCore.Mvc;
using TaskManagement.Application.Services;
using TaskManagement.Application.WorkItems.Commands.CreateWorkItem;
using TaskManagement.Contracts.WorkItems;
using DomainWorkItemPriorityType = TaskManagement.Domain.WorkItems.WorkItemPriorityType;
using DomainWorkItemStatusType = TaskManagement.Domain.WorkItems.WorkItemStatusType;

namespace TaskManagement.API.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class WorkItemsController(IDependencyMediator mediator) : ControllerBase
  {
    [HttpPost]
    public async Task<ActionResult> CreateWorkItem(CreateWorkItemRequest request)
    {
      if (DomainWorkItemPriorityType.TryFromName(request.WorkItemPriorityType.ToString(), out var workItemPriority))
      {
        return Problem(statusCode: StatusCodes.Status400BadRequest, detail: "Invalid WorkItemPriorityType");
      }

      if (DomainWorkItemStatusType.TryFromName(request.WorkItemStatusType.ToString(), out var workItemStatus))
      {
        return Problem(statusCode: StatusCodes.Status400BadRequest, detail: "Invalid WorkItemStatusType");
      }

      var command = new CreateWorkItemCommand(request.UserId, request.Title, request.Description, request.DueDate, workItemPriority, request.WorkItemStatusType);
      var createWorkItemResult = await mediator.Send(command);

      return createWorkItemResult.MatchFirst(workItem => Ok(new CreateWorkItemResponse(workItem.UserId, workItem.Title, workItem.Description, workItem.DueDate, workItem.WorkItemPriorityType, workItem.WorkItemStatusType)),
      error => Problem());
    }
  }
}