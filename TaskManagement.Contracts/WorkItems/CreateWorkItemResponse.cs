namespace TaskManagement.Contracts.WorkItems
{
  public record CreateWorkItemResponse(Guid UserId, string Title, string Description, DateTime DueDate, string Priority, string Status);
}