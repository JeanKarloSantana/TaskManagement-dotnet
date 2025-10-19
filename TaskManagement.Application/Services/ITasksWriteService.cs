namespace TaskManagement.Application.Services
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