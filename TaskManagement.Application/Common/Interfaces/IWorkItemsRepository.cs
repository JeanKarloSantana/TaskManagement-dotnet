using TaskManagement.Domain.WorkItems;

namespace TaskManagement.Application.Common.Interfaces
{
  public interface IWorkItemRepository : IBaseRepository<WorkItem>
  {
    Task AddWorkItemAsync(WorkItem workItem);
    Task<WorkItem> GetWorkItemByIdAsync(Guid workItemId);
  }
}