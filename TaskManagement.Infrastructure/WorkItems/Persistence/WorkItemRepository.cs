using TaskManagement.Application.Common.Interfaces;
using TaskManagement.Domain.WorkItems;
using TaskManagement.Infrastructure.Common.Persistence;

namespace TaskManagement.Infrastructure.WorkItems.Persistence
{

  public class WorkItemRepository(TaskManagementDbContext context) : BaseRepository<WorkItem>(context), IWorkItemRepository
  {
    private readonly static List<WorkItem> _workItems = new();

    public Task AddWorkItemAsync(WorkItem workItem)
    {
      _workItems.Add(workItem);

      return Task.CompletedTask;
    }

    public Task<WorkItem> GetWorkItemByIdAsync(Guid workItemId)
    {
      var workItem = _workItems.FirstOrDefault(wi => wi.Id == workItemId);
      return Task.FromResult(workItem);
    }
  }
}