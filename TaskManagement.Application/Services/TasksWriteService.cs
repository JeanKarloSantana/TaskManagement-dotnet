
namespace TaskManagement.Application.Services
{
  public class TasksService : ITasksService
  {
    public Guid CreateTask(Guid userId, string title, string description, DateTime dueDate, string priority, string status)
    {
      return Guid.NewGuid();
    }
  }
}
