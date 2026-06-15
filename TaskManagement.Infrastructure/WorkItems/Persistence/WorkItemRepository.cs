using TaskManagement.Application.Common.Interfaces;
using TaskManagement.Domain.WorkItems;
using TaskManagement.Infrastructure.Common.Persistence;

namespace TaskManagement.Infrastructure.WorkItems.Persistence
{

  public class WorkItemRepository(TaskManagementDbContext context) : BaseRepository<WorkItem>(context), IWorkItemRepository
  {
    private readonly static List<WorkItem> _workItems = [];

    public Task AddWorkItemAsync(WorkItem workItem)
    {
      Add(workItem);

      return Task.CompletedTask;
    }

    public Task<WorkItem?> GetWorkItemByIdAsync(Guid workItemId)
    {
      WorkItem? workItem = _workItems.FirstOrDefault(wi => wi.Id == workItemId);
      
      return Task.FromResult(workItem);
    }
  }
}
