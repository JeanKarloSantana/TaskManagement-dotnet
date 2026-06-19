namespace TaskManagement.Application.Services.TasksWrite
{
  public interface ITasksService
  {
    Guid CreateTask(
      Guid userId,
      string title,
      string description,
      DateTime dueDate,
      string priority,
      string status);
  }
}