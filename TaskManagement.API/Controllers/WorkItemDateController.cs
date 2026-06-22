using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Application.WorkItemDates.Commands;

namespace TaskManagement.API.Controllers;

[ApiController]
[Route("api/work-items")]
public class WorkItemDateController(IDependencyMediator mediator) : ControllerBase
{
    [Authorize]
    [HttpPost("dates/update")]
    public async Task<ActionResult> UpdateWorkItemDateTime(UpdateWorkItemDateCommand request)
    {
        var result = await mediator.Send(request);
        return result.MatchFirst<ActionResult>(result => Ok(), error => Problem(statusCode: StatusCodes.Status400BadRequest, detail: error.Description));
    }
}