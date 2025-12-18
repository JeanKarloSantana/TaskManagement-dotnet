using TaskManagement.Domain.WorkItems;

namespace TaskManagement.Contracts.WorkItems
{
  public record CreateWorkItemResponse(Guid UserId, string Title, string Description, DateTime DueDate, WorkItemPriorityType Priority, WorkItemStatusType Status);
}