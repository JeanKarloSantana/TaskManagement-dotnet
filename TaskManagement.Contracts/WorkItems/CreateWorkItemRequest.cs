namespace TaskManagement.Contracts.WorkItems
{
  public record CreateWorkItemRequest(Guid UserId, string Title, string Description, DateTime DueDate, string Priority, string Status);
}