using TaskManagement.Domain.WorkItems;

namespace TaskManagement.Contracts.WorkItems
{
  public record CreateWorkItemRequest(Guid UserId, string Title, string Description, DateTime DueDate, WorkItemPriorityType WorkItemPriorityType, WorkItemStatusType WorkItemStatusType);
}