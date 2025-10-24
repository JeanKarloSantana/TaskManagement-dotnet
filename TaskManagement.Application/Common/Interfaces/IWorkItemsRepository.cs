using TaskManagement.Domain.WorkItems;

namespace TaskManagement.Application.Common.Interfaces
{
  public interface IWorkItemRepository
  {
    Task AddWorkItemAsync(WorkItem workItem);
    // Other repository methods can be defined here
  }
}