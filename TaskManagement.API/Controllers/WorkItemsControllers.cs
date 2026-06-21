using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Application.WorkItems.Commands;
using TaskManagement.Contracts.WorkItems;
using DomainWorkItemPriorityType = TaskManagement.Domain.WorkItems.WorkItemPriorityType;
using DomainWorkItemStatusType = TaskManagement.Domain.WorkItems.WorkItemStatusType;

namespace TaskManagement.API.Controllers
{
  [ApiController]
   [Route("api/workitem")]
  public class WorkItemsController(IDependencyMediator mediator) : ControllerBase
  {
    [Authorize]
    [HttpPost("create")]
    public async Task<ActionResult> CreateWorkItem(CreateWorkItemRequest request)
    {
      var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);

      if (!Guid.TryParse(userIdClaim, out var userId))
      {
        return Unauthorized();
      }

      if (!DomainWorkItemPriorityType.TryFromName(request.WorkItemPriorityType.ToString(), out var workItemPriority))
      {
        return Problem(statusCode: StatusCodes.Status400BadRequest, detail: "Invalid WorkItemPriorityType");
      }

      if (!DomainWorkItemStatusType.TryFromName(request.WorkItemStatusType.ToString(), out var workItemStatus))
      {
        return Problem(statusCode: StatusCodes.Status400BadRequest, detail: "Invalid WorkItemStatusType");
      }

      var command = new CreateWorkItemCommand(UserId: userId, Title: request.Title, Description: request.Description, DueDate: request.DueDate, Priority: workItemPriority, Status: workItemStatus);
      var createWorkItemResult = await mediator.Send(command);

      return createWorkItemResult.MatchFirst(workItem => Ok(new CreateWorkItemResponse(workItem.UserId, workItem.Title, workItem.Description, workItem.DueDate, workItem.WorkItemPriorityType, workItem.WorkItemStatusType)),
      error => Problem());
    }
  }

  /*[Authorize]
  [HttpGet("get/all/by/user-id")]
  public async Task<ActionResult> GetWorkItemByUserId() {

  }*/
}