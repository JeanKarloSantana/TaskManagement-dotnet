using ErrorOr;
using TaskManagement.Domain.WorkItems;

namespace TaskManagement.Application.WorkItems.Commands

{
  public record CreateWorkItemCommand(Guid UserId, string Title, string Description, DateTime DueDate, WorkItemPriorityType Priority, WorkItemStatusType Status) : IRequest<ErrorOr<WorkItem>>;

}

