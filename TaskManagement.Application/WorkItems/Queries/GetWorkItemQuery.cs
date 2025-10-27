using ErrorOr;
using TaskManagement.Domain.WorkItems;

namespace TaskManagement.Application.WorkItems.Queries
{
  public record GetWorkItemQuery(Guid WorkItemId) : IRequest<ErrorOr<WorkItem>>;
}