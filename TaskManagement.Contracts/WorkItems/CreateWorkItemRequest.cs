namespace TaskManagement.Contracts.WorkItems
{
  public record CreateWorkItemRequest(string Title, string Description, DateTime DueDate, string WorkItemPriorityType, string WorkItemStatusType);
}