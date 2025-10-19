namespace TaskManagement.Application.Tasks.Commands.CreateTask

{
  public record CreateTaskCommand(Guid userId, string title, string description, DateTime dueDate, string priority, string status) : IRequest<Guid>;

}